using MassTransit;
using MediatR;
using Shared.Events.MediaService;
using Shared.Objects;

namespace ContentModerator.Application.UseCases.ClassifyMedia
{
    internal class ClassifyMediaHandler(IImageFrameExtractor imageFrameExtractor, IVideoFrameExtractor videoFrameExtractor, TempDirectoryManager tempDirectoryManager, IBlobService blobService, IPublishEndpoint publishEndpoint, IModerator moderator) : IRequestHandler<ClassifyMediaRequest>
    {
        private readonly IImageFrameExtractor _imageFrameExtractor = imageFrameExtractor;
        private readonly IVideoFrameExtractor _videoFrameExtractor = videoFrameExtractor;
        private readonly TempDirectoryManager _tempDirectoryManager = tempDirectoryManager;
        private readonly IBlobService _blobService = blobService;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly IModerator _moderator = moderator;

        public async Task Handle(ClassifyMediaRequest request, CancellationToken cancellationToken)
        {
            double resolution = 720;
            double fps = 1;

            try
            {
                _tempDirectoryManager.Create();

                var inputStream = await _blobService.ReadAsync(request.ContainerName, request.BlobName, cancellationToken);
                var inputPath = await _tempDirectoryManager.AddAsync(inputStream, cancellationToken);
                inputStream.Close();
                inputStream.Dispose();

                var tempPath = _tempDirectoryManager.GenerateUniqPath();
                IEnumerable<string> outputPaths;
                if(request.Type == MediaType.Video)
                    outputPaths = await _videoFrameExtractor.ExtractAsync(inputPath, tempPath, resolution, fps, cancellationToken);
                else
                    outputPaths = [await _imageFrameExtractor.ExtractAsync(inputPath, tempPath, resolution, cancellationToken)];
                var tasks = outputPaths.Select(path => _moderator.ClassifyImageAsync(path, cancellationToken));
                var moderationResult = ModerationResult.Max(await Task.WhenAll(tasks));

                _tempDirectoryManager.Delete();

                await _publishEndpoint.Publish(new MediaClassfiedEvent(request.Id, moderationResult), cancellationToken);
            }
            catch (Exception)
            {
                _tempDirectoryManager.Delete();
                throw;
            }

        }
    }
}

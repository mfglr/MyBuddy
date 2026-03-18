using MassTransit;
using Media.Models;
using MediatR;

namespace ContentModerator.Application.UseCases.ClassifyMedia
{
    internal class ClassifyMediaHandler(ClassifyMediaMapper mapper, IPublishEndpoint publishEndpoint, IImageFrameExtractor imageFrameExtractor, IVideoFrameExtractor videoFrameExtractor, TempDirectoryManager tempDirectoryManager, IBlobService blobService, IModerator moderator) : IRequestHandler<ClassifyMediaRequest>
    {
        public async Task Handle(ClassifyMediaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                tempDirectoryManager.Create();

                string inputPath;
                using (var inputStream = await blobService.ReadAsync(request.ContainerName, request.BlobName, cancellationToken))
                {
                    inputPath = await tempDirectoryManager.AddAsync(inputStream, cancellationToken);
                }

                var tempPath = tempDirectoryManager.GenerateUniqPath();
                IEnumerable<string> outputPaths;
                if(request.Type == MediaType.Video)
                    outputPaths = await videoFrameExtractor.ExtractAsync(
                        inputPath,
                        tempPath,
                        request.Instruction.Resolution,
                        request.Instruction.Fps,
                        cancellationToken
                    );
                else
                    outputPaths = [await imageFrameExtractor.ExtractAsync(inputPath, tempPath, request.Instruction.Resolution, cancellationToken)];
                var tasks = outputPaths.Select(path => moderator.ClassifyImageAsync(path, cancellationToken));
                var moderationResult = ModerationResult.Max(await Task.WhenAll(tasks));

                tempDirectoryManager.Delete();

                var @event = mapper.Map(request, moderationResult);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            catch (Exception)
            {
                tempDirectoryManager.Delete();
                throw;
            }
        }
    }
}

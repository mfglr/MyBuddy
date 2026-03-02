using MassTransit;
using MediatR;
using Shared.Events.SharedObjects;

namespace ContentModerator.Application.UseCases.ClassifyMedia
{
    internal class ClassifyMediaHandler(ClassifyMediaMapper mapper, IPublishEndpoint publishEndpoint, IImageFrameExtractor imageFrameExtractor, IVideoFrameExtractor videoFrameExtractor, TempDirectoryManager tempDirectoryManager, IBlobService blobService, IModerator moderator) : IRequestHandler<ClassifyMediaRequest>
    {
        public async Task Handle(ClassifyMediaRequest request, CancellationToken cancellationToken)
        {
            if(request.Instruction.ModerationInstruction is null)
            {
                var @event = mapper.MapValidatedEvent(request, null);
                await publishEndpoint.Publish(@event, cancellationToken);
                return;
            }
                
            double resolution = request.Instruction.ModerationInstruction.Resolution;
            double fps = request.Instruction.ModerationInstruction.Fps;

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
                    outputPaths = await videoFrameExtractor.ExtractAsync(inputPath, tempPath, resolution, fps, cancellationToken);
                else
                    outputPaths = [await imageFrameExtractor.ExtractAsync(inputPath, tempPath, resolution, cancellationToken)];
                var tasks = outputPaths.Select(path => moderator.ClassifyImageAsync(path, cancellationToken));
                var moderationResult = ModerationResult.Max(await Task.WhenAll(tasks));

                tempDirectoryManager.Delete();

                if (request.Instruction.ModerationInstruction.IsValidModerationResult(moderationResult))
                {
                    var @event = mapper.MapValidatedEvent(request, moderationResult);
                    await publishEndpoint.Publish(@event, cancellationToken);
                }
                else
                {
                    var @event = mapper.MapInvalidatedEvent(request, moderationResult);
                    await publishEndpoint.Publish(@event, cancellationToken);
                }
            }
            catch (Exception)
            {
                tempDirectoryManager.Delete();
                throw;
            }
        }
    }
}

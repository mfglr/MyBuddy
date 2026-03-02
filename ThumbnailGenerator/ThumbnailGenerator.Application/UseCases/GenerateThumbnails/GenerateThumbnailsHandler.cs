using MassTransit;
using MediatR;
using Shared.Events.MediaService;
using Shared.Events.SharedObjects;

namespace ThumbnailGenerator.Application.UseCases.GenerateThumbnails
{
    internal class GenerateThumbnailsHandler(GenerateThumbnailsMapper mapper, IPublishEndpoint publishEndpoint, IThumbnailGenerator thumbnailGenerator, IBlobService blobService, TempDirectoryManager tempDirectoryManager) : IRequestHandler<GenerateThumbnailsRequest>
    {
        public async Task Handle(GenerateThumbnailsRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<string>? blobNames = null;
            try
            {
                tempDirectoryManager.Create();

                string inputPath;
                using (var inputStream = await blobService.GetAsync(request.ContainerName, request.BlobName, cancellationToken))
                {
                    inputPath = await tempDirectoryManager.AddAsync(inputStream, cancellationToken);
                }

                var tasks = request.Instructions.Select(instruction => GenerateThumbnailAsync(request.ContainerName, inputPath, instruction, cancellationToken));
                blobNames = await Task.WhenAll(tasks);

                tempDirectoryManager.Delete();

                var @event = mapper.Map(request, blobNames);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            catch (Exception)
            {
                tempDirectoryManager.Delete();
                if (blobNames != null)
                    await blobService.DeleteAsync(request.ContainerName, blobNames, cancellationToken);
                throw;
            }
        }

        private async Task<string> GenerateThumbnailAsync(
            string containerName,
            string inputPath,
            ThumbnailInstruction instruction,
            CancellationToken cancellationToken
        )
        {
            var outputPath = tempDirectoryManager.GenerateUniqPath("jpeg");
            await thumbnailGenerator.GenerateAsync(inputPath, outputPath, instruction.Resolution, instruction.IsSquare, cancellationToken);
            using var fileStream = File.OpenRead(outputPath);
            return await blobService.UploadAsync(fileStream, containerName, cancellationToken);
        }
    }
}

using MassTransit;
using MediatR;

namespace ThumbnailGenerator.Application.UseCases.GenerateThumbnail
{
    internal class GenerateThumbnailHandler(
        GenerateThumbnailMapper mapper,
        IThumbnailGenerator thumbnailGenerator,
        IBlobService blobService,
        TempDirectoryManager tempDirectoryManager,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<GenerateThumbnailRequest>
    {
        public async Task Handle(GenerateThumbnailRequest request, CancellationToken cancellationToken)
        {
            string? blobName = null;
            try
            {
                tempDirectoryManager.Create();

                string inputPath;
                using (var inputStream = await blobService.GetAsync(request.ContainerName, request.BlobName, cancellationToken))
                {
                    inputPath = await tempDirectoryManager.AddAsync(inputStream, cancellationToken);
                }

                var outputPath = tempDirectoryManager.GenerateUniqPath("jpeg");
                await thumbnailGenerator.GenerateAsync(
                    inputPath,
                    outputPath,
                    request.Instruction.Resolution,
                    request.Instruction.IsSquare,
                    cancellationToken
                );

                using (var fileStream = File.OpenRead(outputPath))
                {
                    blobName = await blobService.UploadAsync(fileStream, request.ContainerName, cancellationToken);
                }

                tempDirectoryManager.Delete();

                var @event = mapper.Map(request, blobName);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            catch (Exception)
            {
                tempDirectoryManager.Delete();
                if (blobName != null)
                    await blobService.DeleteAsync(request.ContainerName, blobName, cancellationToken);
                throw;
            }
        }
    }
}

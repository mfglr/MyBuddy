using Shared.Events.MediaService;

namespace ThumbnailGenerator.Application.UseCases.GenerateThumbnail
{
    internal class GenerateThumbnailMapper
    {
        public ThumbnailGeneratedEvent Map(GenerateThumbnailRequest request, string blobName) =>
            new(
                request.ContainerName,
                request.BlobName,
                new(
                    blobName,
                    request.Instruction.Resolution,
                    request.Instruction.IsSquare
                )
            );
    }
}

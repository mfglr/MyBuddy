using MediatR;
using Shared.Events.SharedObjects;

namespace ThumbnailGenerator.Application.UseCases.GenerateThumbnails
{
    public record GenerateThumbnailsRequest(
        string ContainerName,
        string BlobName,
        IEnumerable<ThumbnailInstruction> Instructions
    ) : IRequest;
}

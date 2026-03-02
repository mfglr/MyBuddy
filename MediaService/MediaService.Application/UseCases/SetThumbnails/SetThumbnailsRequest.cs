using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.SetThumbnails
{
    public record SetThumbnailsRequest(
        string ContainerName,
        string BlobName,
        IEnumerable<Thumbnail> Thumbnails
    ) : IRequest;
}

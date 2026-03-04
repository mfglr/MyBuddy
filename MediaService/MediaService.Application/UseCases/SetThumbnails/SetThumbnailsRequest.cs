using MediaService.Domain;
using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.SetThumbnails
{
    public record SetThumbnailsRequest(
        MediaListId Id,
        string BlobName,
        IEnumerable<Thumbnail> Thumbnails
    ) : IRequest;
}

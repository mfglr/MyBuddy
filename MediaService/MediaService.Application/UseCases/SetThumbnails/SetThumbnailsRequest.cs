using MediaService.Domain;
using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.SetThumbnails
{
    public record SetThumbnailsRequest(
        MediaId Id,
        IEnumerable<Thumbnail> Thumbnails
    ) : IRequest;
}

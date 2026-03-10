using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.AddThumbnail
{
    public record AddThumbnailRequest(
        string ContainerName,
        string BlobName,
        Thumbnail Thumbnail
    ) : IRequest;
}

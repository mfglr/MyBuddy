using Media.Models;
using MediatR;

namespace MediaService.Application.UseCases.AddThumbnail
{
    public record AddThumbnailRequest(
        string ContainerName,
        string BlobName,
        Thumbnail Thumbnail
    ) : IRequest;
}

using Media.Models;
using MediatR;

namespace UserService.Application.UseCases.SetMedia
{
    public record SetMediaRequest(
        Guid Id,
        string BlobName,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails
    ) : IRequest;
}

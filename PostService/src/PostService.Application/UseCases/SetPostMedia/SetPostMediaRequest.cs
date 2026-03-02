using MediatR;
using Shared.Events.SharedObjects;

namespace PostService.Application.UseCases.SetPostMedia
{
    public record SetPostMediaRequest(
        Guid Id,
        string BlobName,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        string? TranscodedBlobName
    ) : IRequest;
}

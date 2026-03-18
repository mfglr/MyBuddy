using Media.Models;
using MediatR;

namespace PostService.Application.UseCases.SetPostMedia
{
    public record SetPostMediaRequest(
        Guid Id,
        string BlobName,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings
    ) : IRequest;
}

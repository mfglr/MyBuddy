using Media.Models;
using MediatR;

namespace AuthServer.Application.UseCases.SetMedia
{
    public record SetMediaRequest(
        Guid Id,
        string BlobName,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings
    ) : IRequest;
}

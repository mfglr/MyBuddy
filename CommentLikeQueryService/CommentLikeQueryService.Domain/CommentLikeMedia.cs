using Media.Models;

namespace CommentLikeQueryService.Domain
{
    public record CommentLikeMedia(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings
    );
}

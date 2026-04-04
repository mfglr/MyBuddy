using Media.Models;

namespace PostLikeQueryService.Domain
{
    public record PostLikeQueryMedia(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings
    );
}

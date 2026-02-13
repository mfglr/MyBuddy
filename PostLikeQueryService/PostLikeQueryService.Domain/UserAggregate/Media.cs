using System.Text.Json.Serialization;

namespace PostLikeQueryService.Domain.UserAggregate
{
    [method: JsonConstructor]
    public record Media(
        string ContainerName,
        string BlobName,
        Metadata Metadata,
        IEnumerable<Thumbnail> Thumbnails,
        ModerationResult ModerationResult
    );
}

using Shared.Events.SharedObjects;
using System.Text.Json.Serialization;

namespace PostQueryService.Shared.Model
{
    [method: JsonConstructor]
    public record Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        string? TranscodedBlobName
    );
}

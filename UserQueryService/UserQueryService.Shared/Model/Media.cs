using Shared.Events.SharedObjects;

namespace UserQueryService.Shared.Model
{
    public record Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails
    );
}

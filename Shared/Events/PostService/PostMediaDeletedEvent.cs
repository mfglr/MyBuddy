using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostMediaDeletedEvent_Content(string Value, ModerationResult ModerationResult);
    public record PostMediaDeletedEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        string? TranscodedBlobName,
        Metadata Metadata,
        ModerationResult ModerationResult,
        IReadOnlyList<Thumbnail> Thumbnails
    );
    public record PostMediaDeletedEvent(
        Guid Id,
        int Version,
        PostMediaDeletedEvent_Content? Content,
        IReadOnlyList<PostMediaDeletedEvent_Media> Media,
        PostMediaDeletedEvent_Media DeletedMedia
    );
}

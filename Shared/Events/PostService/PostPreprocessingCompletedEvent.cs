using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostPreprocessingCompletedEvent_Content(string Value, ModerationResult ModerationResult);
    public record PostPreprocessingCompletedEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        string? TranscodedBlobName,
        Metadata Metada,
        ModerationResult ModerationResult,
        IReadOnlyList<Thumbnail> Thumbnails
    );
    public record PostPreprocessingCompletedEvent(
        Guid Id,
        PostPreprocessingCompletedEvent_Content? Content,
        IReadOnlyList<PostPreprocessingCompletedEvent_Media> Media
    );
}

using Shared.Events.SharedObjects;

namespace Shared.Events.PostService
{
    public record PostRestoredEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record PostRestoredEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings,
        MediaInstruction Instruction
    );
    public record PostRestoredEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        PostRestoredEvent_Content? Content,
        IEnumerable<PostRestoredEvent_Media> Media
    );
}

using Shared.Events.SharedObjects;

namespace Shared.Events.PostService
{
    public record PostDeletedEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record PostDeletedEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings,
        MediaInstruction Instruction
    );
    public record PostDeletedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        PostDeletedEvent_Content? Content,
        IEnumerable<PostDeletedEvent_Media> Media
    );
}

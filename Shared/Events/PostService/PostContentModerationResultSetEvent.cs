using Shared.Events.SharedObjects;

namespace Shared.Events.PostService
{
    public record PostContentModerationResultSetEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record PostContentModerationResultSetEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        IEnumerable<Transcoding> Transcodings,
        MediaInstruction Instuction
    );
    public record PostContentModerationResultSetEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        bool IsValidVersion,
        Guid UserId,
        PostContentModerationResultSetEvent_Content? Content,
        IEnumerable<PostContentModerationResultSetEvent_Media> Media
    );
}

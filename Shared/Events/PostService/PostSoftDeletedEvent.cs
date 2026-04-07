using Media.Models;

namespace Shared.Events.PostService
{
    public record PostDeletedEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record PostSoftDeletedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? SoftDeletedAt,
        bool IsHardDeleted,
        int Version,
        Guid UserId,
        PostDeletedEvent_Content? Content,
        IEnumerable<MediaMessage> Media
    );
}

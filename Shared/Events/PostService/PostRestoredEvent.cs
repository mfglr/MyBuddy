using Media.Models;

namespace Shared.Events.PostService
{
    public record PostRestoredEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record PostRestoredEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? SoftDeletedAt,
        bool IsHardDeleted,
        int Version,
        Guid UserId,
        PostRestoredEvent_Content? Content,
        IEnumerable<MediaMessage> Media
    );
}

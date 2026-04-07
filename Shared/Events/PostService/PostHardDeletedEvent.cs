using Media.Models;

namespace Shared.Events.PostService
{
    public record PostHardDeletedEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record PostHardDeletedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? SoftDeletedAt,
        bool IsHardDeleted,
        int Version,
        Guid UserId,
        PostHardDeletedEvent_Content? Content,
        IEnumerable<MediaMessage> Media
    );
}

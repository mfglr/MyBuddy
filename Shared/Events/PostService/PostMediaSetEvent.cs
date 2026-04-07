using Media.Models;

namespace Shared.Events.PostService
{
    public record PostMediaSetEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record PostMediaSetEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? SoftDeletedAt,
        bool IsHardDeleted,
        int Version,
        Guid UserId,
        PostMediaSetEvent_Content? Content,
        IEnumerable<MediaMessage> Media
    );
}

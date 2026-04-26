using Media.Models;

namespace Shared.Events.PostService
{
    public record PostContentModerationResultSetEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record PostContentModerationResultSetEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        PostContentModerationResultSetEvent_Content? Content,
        IEnumerable<MediaMessage> Media
    );
}

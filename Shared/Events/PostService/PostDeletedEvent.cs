using Media.Models;

namespace Shared.Events.PostService
{
    public record PostDeletedEvent_Content(
        string Value,
        ModerationResult? ModerationResult
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
        IEnumerable<MediaMessage> Media
    );
}

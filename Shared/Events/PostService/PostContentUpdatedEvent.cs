using Media.Models;

namespace Shared.Events.PostService
{
    public record PostContentUpdatedEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record PostContentUpdatedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        PostContentUpdatedEvent_Content? Content,
        IEnumerable<MediaMessage> Media
    );
}

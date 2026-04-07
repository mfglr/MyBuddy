using Media.Models;

namespace Shared.Events.PostService
{
    public record PostCreatedEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record PostCreatedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        PostCreatedEvent_Content? Content,
        IEnumerable<MediaMessage> Media
    );
}

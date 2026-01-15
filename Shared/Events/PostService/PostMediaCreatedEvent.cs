using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostMediaCreatedEvent_Content(string Value, ModerationResult ModerationResult);
    public record PostMediaCreatedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid UserId,
        int Version,
        bool IsDeleted,
        PostMediaCreatedEvent_Content? Content,
        IReadOnlyList<Media> Media
    );
}

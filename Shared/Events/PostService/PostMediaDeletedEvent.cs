using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostMediaDeletedEvent_Content(string Value, ModerationResult ModerationResult);
    public record PostMediaDeletedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid UserId,
        int Version,
        bool IsDeleted,
        PostMediaDeletedEvent_Content? Content,
        IReadOnlyList<Media> Media
    );
}

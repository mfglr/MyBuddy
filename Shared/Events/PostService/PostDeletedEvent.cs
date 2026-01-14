using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostDeletedEvent_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record PostDeletedEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid UserId,
        int Version,
        bool IsDeleted,
        PostDeletedEvent_Content? Content,
        IReadOnlyList<Media> Media
    );
}

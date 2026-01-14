using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostMediaSetEvent_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record PostMediaSetEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid UserId,
        int Version,
        bool IsDeleted,
        PostMediaSetEvent_Content? Content,
        IReadOnlyList<Media> Media
    );
}

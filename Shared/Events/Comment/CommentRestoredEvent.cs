using Shared.Events.SharedObjects;

namespace Shared.Events.Comment
{
    public record CommentRestoredEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record CommentRestoredEvent(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        Guid? PostId,
        Guid? ParentId,
        Guid? RepliedId,
        CommentRestoredEvent_Content Content
    );
}

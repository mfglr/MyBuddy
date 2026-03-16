using Shared.Events.SharedObjects;

namespace Shared.Events.Comment
{
    public record CommentDeletedEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record CommentDeletedEvent(
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
        CommentDeletedEvent_Content Content
    );
}

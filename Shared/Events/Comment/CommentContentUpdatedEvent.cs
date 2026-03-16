using Shared.Events.SharedObjects;

namespace Shared.Events.Comment
{
    public record CommentContentUpdatedEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record CommentContentUpdatedEvent(
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
        CommentContentUpdatedEvent_Content Content
    );
}

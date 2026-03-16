using Shared.Events.SharedObjects;

namespace Shared.Events.Comment
{
    public record CommentContentModerationResultSetEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record CommentContentModerationResultSetEvent(
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
        CommentContentModerationResultSetEvent_Content Content
    );
}

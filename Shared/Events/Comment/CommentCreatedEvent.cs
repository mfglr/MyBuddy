using Media.Models;

namespace Shared.Events.Comment
{

    public record CommentCreatedEvent_Content(
        string Value,
        ModerationResult? ModerationResult
    );
    public record CommentCreatedEvent(
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
        CommentCreatedEvent_Content Content
    );
}

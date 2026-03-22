using CommentService.Domain;
using Shared.Events;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.CreateComment
{
    internal class CreateCommentMapper
    {
        public CommentCreatedEvent_Content Map(Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public CommentCreatedEvent Map(Comment comment,CurrentUser user) =>
            new(
                comment.Id,
                comment.CreatedAt,
                comment.UpdatedAt,
                comment.DeletedAt,
                comment.IsDeleted,
                comment.Version,
                comment.UserId,
                comment.PostId,
                comment.ParentId,
                comment.RepliedId,
                Map(comment.Content),
                user
            );
    }
}

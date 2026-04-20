using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.DeleteComment
{
    internal class DeleteCommentMapper
    {
        public CommentDeletedEvent_Content Map(Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public CommentDeletedEvent Map(Comment comment) =>
            new(
                comment.Id,
                comment.CreatedAt,
                comment.UpdatedAt,
                true,
                comment.Version,
                comment.UserId,
                comment.PostId,
                comment.ParentId,
                comment.RepliedId,
                Map(comment.Content)
            );
    }
}

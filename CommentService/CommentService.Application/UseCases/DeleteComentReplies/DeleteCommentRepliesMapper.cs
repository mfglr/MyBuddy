using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.DeleteComentReplies
{
    internal class DeleteCommentRepliesMapper
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
                comment.DeletedAt,
                comment.IsDeleted,
                comment.Version,
                comment.UserId,
                comment.PostId,
                comment.ParentId,
                comment.RepliedId,
                Map(comment.Content)
            );
    }
}

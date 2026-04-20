using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.SetCommentContentModerationResult
{
    internal class SetCommentContentModerationResultMapper
    {
        public CommentContentModerationResultSetEvent_Content Map(Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public CommentContentModerationResultSetEvent Map(Comment comment) =>
            new(
                comment.Id,
                comment.CreatedAt,
                comment.UpdatedAt,
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

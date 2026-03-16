using CommentService.Domain;
using Shared.Events.Comment;

namespace CommentService.Application.UseCases.UpdateCommentContent
{
    internal class UpdateCommentContentMapper
    {
        public CommentContentUpdatedEvent_Content Map(Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public CommentContentUpdatedEvent Map(Comment comment) =>
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

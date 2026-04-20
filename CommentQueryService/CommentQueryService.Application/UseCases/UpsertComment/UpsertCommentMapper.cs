using CommentQueryService.Domain.CommentAggregate;
using CommentQueryService.Domain.UserAggregate;

namespace CommentQueryService.Application.UseCases.UpsertComment
{
    internal class UpsertCommentMapper
    {
        public CommentUser Map(User user) =>
            new(
                user.Version,
                user.Name,
                user.UserName,
                user.Media
            );

        public CommentContent Map(UpsertCommentRequest_Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );
 
        public Comment Map(UpsertCommentRequest request, User user) =>
            new(
                request.Id,
                request.CreatedAt,
                request.UpdatedAt,
                request.Version,
                request.UserId,
                request.PostId,
                request.ParentId,
                request.RepliedId,
                Map(request.Content),
                Map(user)
            );
    }
}

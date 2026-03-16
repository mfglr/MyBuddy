using CommentQueryService.Shared.Dto;
using CommentQueryService.Shared.Model;

namespace CommentQueryService.Shared.PostgreSql.QuerRepositories
{
    internal static class CommentResponseQueryMapper
    {
        public static IQueryable<CommentResponse> ToCommentResponse(this IQueryable<Comment> query, SqlContext context) =>
            query
                .Join(
                    context.Users,
                    post => post.UserId,
                    user => user.Id,
                    (comment, user) => new CommentResponse(
                        comment.Id,
                        comment.CreatedAt,
                        comment.UpdatedAt,
                        comment.DeletedAt,
                        comment.IsDeleted,
                        comment.PostId,
                        comment.ParentId,
                        new CommentResponse_Content(
                            comment.Content.Value,
                            comment.Content.ModerationResult
                        ),
                        comment.ChildCount,
                        comment.LikeCount,
                        user.Id,
                        user.UserName,
                        user.Name,
                        user.Media
                    )
                );
    }
}

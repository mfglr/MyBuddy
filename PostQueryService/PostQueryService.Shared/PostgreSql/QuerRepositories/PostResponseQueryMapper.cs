using PostQueryService.Shared.Model;

namespace PostQueryService.Shared.PostgreSql.QuerRepositories
{
    internal static class PostResponseQueryMapper
    {
        public static IQueryable<PostResponse> ToPostResponse(this IQueryable<Post> query, SqlContext context) =>
            query
                .Join(
                    context.Users,
                    post => post.UserId,
                    user => user.Id,
                    (post, user) => new PostResponse(
                        user.Id,
                        user.UserName,
                        user.Name,
                        user.Media,
                        post.Id,
                        post.CreatedAt,
                        post.UpdatedAt,
                        post.Content,
                        post.Media,
                        post.LikeCount,
                        post.CommentCount
                    )
                );
    }
}

using PostQueryService.Shared.Model;

namespace PostQueryService.Shared.PostgreSql.QuerRepositories
{
    internal static class InternPostResponseQueryMapper
    {
        public static IQueryable<InternalPostResponse> ToInternalPostResponse(this IQueryable<Post> query, SqlContext context) =>
            query
                .Join(
                    context.Users,
                    post => post.UserId,
                    user => user.Id,
                    (post, user) => new InternalPostResponse(
                        user.Id,
                        user.Name,
                        user.UserName,
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

using PostLikeQueryService.Domain.PostLikeAggregate;

namespace PostLikeQueryService.Infrastructure.PostgreSql
{

    internal static class PostLikeQueryMapper
    {
        public static IQueryable<InternalPostLikeResponse> ToPostLikeResponse(this IQueryable<PostLike> query, SqlContext context) =>
            query
                .Join(
                    context.Users,
                    postLike => postLike.UserId,
                    user => user.Id,
                    (postLike, user) => new InternalPostLikeResponse(
                        user.Id,
                        user.Name,
                        user.UserName,
                        user.Media,
                        postLike.CreatedAt
                    )
                );
    }
}

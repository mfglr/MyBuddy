using PostLikeQueryService.Shared.Dto;
using PostLikeQueryService.Shared.Model;

namespace PostLikeQueryService.Shared.PostgreSql.QuerRepositories
{
    internal static class PostUserLikeResponseQueryMapper
    {
        public static IQueryable<PostUserLikeResponse> ToPostUserLikeResponse(this IQueryable<PostUserLike> query, SqlContext context) =>
            query
                .Join(
                    context.Users,
                    post => post.UserId,
                    user => user.Id,
                    (pul, user) => new PostUserLikeResponse(
                        pul.SequenceId,
                        pul.CreatedAt,
                        user.Id,
                        user.UserName,
                        user.Name,
                        user.Media
                    )
                );
    }
}

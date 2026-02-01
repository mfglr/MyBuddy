using PostQueryService.Domain.PostDomain;
using Shared.Events;

namespace PostQueryService.Infrastructure.MsSql.QuerRepositories
{
    internal static class InternPostResponseQueryMapper
    {
        public static IQueryable<InternalPostResponse> ToInternalPostResponse(this IQueryable<Post> query, MsSqlContext context) =>
            query
                .Join(
                    context.Users,
                    post => post.UserId,
                    user => user.Id,
                    (post, user) => new InternalPostResponse(
                        post.Id,
                        post.CreatedAt,
                        post.UpdatedAt,
                        post.Content != null
                            ? new InternalPostResponse_Content(
                                post.Content.Value,
                                new ModerationResult(
                                    post.Content.ModerationResult.Hate,
                                    post.Content.ModerationResult.SelfHarm,
                                    post.Content.ModerationResult.Sexual,
                                    post.Content.ModerationResult.Violence
                                )
                            )
                            : null,
                        post.Media,
                        post.UserId,
                        user.Name,
                        user.UserName,
                        user.Media
                    )
                );
    }
}

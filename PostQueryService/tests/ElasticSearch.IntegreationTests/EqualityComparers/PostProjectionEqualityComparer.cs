using PostQueryService.Domain.PostProjectionAggregate;

namespace ElasticSearch.IntegreationTests.EqualityComparers
{
    internal static class PostProjectionEqualityComparer
    {
        public static bool IsEqual(PostProjection x, PostProjection y) =>
            x.Id == y.Id &&
            x.UserId == y.UserId &&
            PostProjectionUserEqualityComparer.IsEqual(x.User, y.User) &&
            PostEqualityComparer.IsEqual(x.Post, y.Post);
    }
}

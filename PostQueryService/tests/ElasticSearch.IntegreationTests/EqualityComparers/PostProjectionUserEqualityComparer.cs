using PostQueryService.Domain.PostProjectionAggregate;

namespace ElasticSearch.IntegreationTests.EqualityComparers
{
    internal static class PostProjectionUserEqualityComparer
    {
        public static bool IsEqual(PostProjectionUser x, PostProjectionUser y) =>
            x.Version == y.Version &&
            x.Name == y.Name &&
            x.UserName == y.UserName &&
            x.Media == y.Media;
    }
}

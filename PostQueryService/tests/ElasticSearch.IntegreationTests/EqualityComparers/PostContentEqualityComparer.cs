using PostQueryService.Domain.PostProjectionAggregate;

namespace ElasticSearch.IntegreationTests.EqualityComparers
{
    internal static class PostContentEqualityComparer
    {
        public static bool IsEqual(PostContent? x, PostContent? y) =>
           x == y ||
           (
               x != null &&
               y != null &&
               x.Value == y.Value &&
               x.ModerationResult == y.ModerationResult
           );
    }
}

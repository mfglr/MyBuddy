using PostQueryService.Domain.PostProjectionAggregate;

namespace ElasticSearch.IntegreationTests.EqualityComparers
{
    internal static class PostEqualityComparer
    {
        public static bool IsEqual(Post x, Post y) =>
            x.CreatedAt == y.CreatedAt &&
            x.UpdatedAt == y.UpdatedAt &&
            x.DeletedAt == y.DeletedAt &&
            x.Version == y.Version &&
            PostContentEqualityComparer.IsEqual(x.Content, y.Content) &&
            MediaListEqualityComparer.IsEqual(x.Media, y.Media);
    }
}

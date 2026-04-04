using PostQueryService.Domain.UserAggregate;

namespace ElasticSearch.IntegreationTests.EqualityComparers
{
    internal static class UserEqualityComparer
    {
        public static bool IsEqual(User x, User y) =>
            x.Id == y.Id &&
            x.DeletedAt == y.DeletedAt &&
            x.Version == y.Version &&
            x.Name == y.Name &&
            x.UserName == y.UserName &&
            x.Media == y.Media;
    }
}

using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Intregration.Tests.EqualityComparers
{
    internal static class UserEqualityComparer
    {
        public static bool IsEqual(User x, User y) =>
            x.Id == y.Id &&
            x.Version == y.Version &&
            x.DeletedAt == y.DeletedAt &&
            x.Name == y.Name &&
            x.UserName == y.UserName &&
            x.Media == y.Media;
    }
}

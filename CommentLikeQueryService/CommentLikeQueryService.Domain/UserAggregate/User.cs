namespace CommentLikeQueryService.Domain.UserAggregate
{
    public class User(Guid id, int version, string? name, string userName, CommentLikeMedia? media)
    {
        public Guid Id { get; private set; } = id;
        public int Version { get; private set; } = version;
        public string? Name { get; private set; } = name;
        public string UserName { get; private set; } = userName;
        public CommentLikeMedia? Media { get; private set; } = media;

        public bool TryUpdate(int version, string? name, string userName, CommentLikeMedia? media)
        {
            if (version <= Version)
                return false;
            Version = version;
            Name = name;
            UserName = userName;
            Media = media;
            return true;
        }
    }
}

namespace PostLikeQueryService.Domain.UserAggregate
{
    public class User(Guid id, int version, DateTime? deletedAt, string? name, string userName, PostLikeQueryMedia? media)
    {
        public Guid Id { get; private set; } = id;
        public int Version { get; private set; } = version;
        public DateTime? DeletedAt { get; private set; } = deletedAt;
        public string? Name { get; private set; } = name;
        public string UserName { get; private set; } = userName;
        public PostLikeQueryMedia? Media { get; private set; } = media;

        public bool TryUpdate(int version, DateTime? deletedAt, string? name, string userName, PostLikeQueryMedia? media)
        {
            if (version <= Version)
                return false;

            Version = version;
            DeletedAt = deletedAt;
            Name = name;
            UserName = userName;
            Media = media;

            return true;
        }

    }
}

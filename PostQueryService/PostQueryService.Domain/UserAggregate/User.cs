namespace PostQueryService.Domain.UserAggregate
{
    public class User(Guid id, DateTime? deletedAt, int version, string? name, string userName, PostQueryMedia? media)
    {
        public Guid Id { get; private set; } = id;
        public DateTime? DeletedAt { get; private set; } = deletedAt;
        public int Version { get; private set; } = version;
        public string? Name { get; private set; } = name;
        public string UserName { get; private set; } = userName;
        public PostQueryMedia? Media { get; private set; } = media;

        public bool TryUpdateUser(DateTime? deletedAt, int version, string? name, string userName, PostQueryMedia? media)
        {
            if (version <= Version)
                return false;

            DeletedAt = deletedAt;
            Version = version;
            Name = name;
            UserName = userName;
            Media = media;
            return true;
        }
    }
}

namespace CommentQueryService.Domain.UserAggregate
{
    public class User(Guid id, DateTime? deletedAt, int version, string? name, string userName, CommentMedia? media)
    {
        public Guid Id { get; private set; } = id;
        public DateTime? DeletedAt { get; private set; } = deletedAt;
        public int Version { get; private set; } = version;
        public string? Name { get; private set; } = name;
        public string UserName { get; private set; } = userName;
        public CommentMedia? Media { get; private set; } = media;
        public IReadOnlyList<int> ProcessedVersions { get; private set; } = [version];

        public bool AllVersionsProcessed => ProcessedVersions.Count == ProcessedVersions.Max();

        public bool TryUpdate(DateTime? deletedAt, int version, string? name, string userName, CommentMedia? media)
        {
            if (version == Version)
                return false;
            ProcessedVersions = [..ProcessedVersions, version];
            if(version > Version)
            {
                DeletedAt = deletedAt;
                Version = version;
                Name = name;
                UserName = userName;
                Media = media;
            }
            return true;
        }
    }
}

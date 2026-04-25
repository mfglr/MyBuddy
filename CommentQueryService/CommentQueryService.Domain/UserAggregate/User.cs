namespace CommentQueryService.Domain.UserAggregate
{
    public class User(Guid id,int version, string? name, string userName, CommentMedia? media)
    {
        public Guid Id { get; private set; } = id;
        public int Version { get; private set; } = version;
        public string? Name { get; private set; } = name;
        public string UserName { get; private set; } = userName;
        public CommentMedia? Media { get; private set; } = media;
        public IReadOnlyList<int> ProcessedVersions { get; private set; } = [version];

        public bool AllVersionsProcessed => ProcessedVersions.Count == ProcessedVersions.Max();

        public bool TryUpdate(int version, string? name, string userName, CommentMedia? media)
        {
            if (version == Version)
                return false;
            ProcessedVersions = [..ProcessedVersions, version];
            if(version > Version)
            {
                Version = version;
                Name = name;
                UserName = userName;
                Media = media;
            }
            return true;
        }
    }
}

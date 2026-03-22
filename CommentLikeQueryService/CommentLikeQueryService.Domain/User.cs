namespace CommentLikeQueryService.Domain
{
    public class User(Guid id, int version, string? name, string userName, UserMedia? media)
    {
        public Guid Id { get; private set; } = id;
        public int Version { get; private set; } = version;
        public string? Name { get; private set; } = name;
        public string UserName { get; private set; } = userName;
        public UserMedia? Media { get; private set; } = media;
    }
}

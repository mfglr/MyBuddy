namespace CommentLikeQueryService.Domain.CommentLikeAggregate
{
    public class CommentLikeUser(int version, string? name, string userName, CommentLikeMedia? media)
    {
        public int Version { get; private set; } = version;
        public string? Name { get; private set; } = name;
        public string UserName { get; private set; } = userName;
        public CommentLikeMedia? Media { get; private set; } = media;
    }
}

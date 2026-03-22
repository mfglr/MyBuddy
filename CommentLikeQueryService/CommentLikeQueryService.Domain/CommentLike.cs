namespace CommentLikeQueryService.Domain
{
    public class CommentLike(DateTime createdAt, DateTime? deletedAt, bool isDeleted, int version)
    {
        public DateTime CreatedAt { get; private set; } = createdAt;
        public DateTime? DeletedAt { get; private set; } = deletedAt;
        public bool IsDeleted { get; private set; } = isDeleted;
        public int Version { get; private set; } = version;
    }
}

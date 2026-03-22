namespace CommentQueryService.Domain
{
    public class Comment(
        DateTime createdAt,
        DateTime? updatedAt,
        DateTime? deletedAt,
        bool isDeleted,
        int version,
        Guid? postId,
        Guid? parentId,
        Guid? repliedId,
        Content content
    )
    {
        public DateTime CreatedAt { get; private set; } = createdAt;
        public DateTime? UpdatedAt { get; private set; } = updatedAt;
        public DateTime? DeletedAt { get; private set; } = deletedAt;
        public bool IsDeleted { get; private set; } = isDeleted;
        public int Version { get; private set; } = version;
        public Guid? PostId { get; private set; } = postId;
        public Guid? ParentId { get; private set; } = parentId;
        public Guid? RepliedId { get; private set; } = repliedId;
        public Content Content { get; private set; } = content;
    }
}

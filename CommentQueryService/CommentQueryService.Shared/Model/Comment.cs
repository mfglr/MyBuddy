namespace CommentQueryService.Shared.Model
{
    public class Comment
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public int Version { get; private set; }
        public Guid UserId { get; private set; }
        public Guid? PostId { get; private set; }
        public Guid? ParentId { get; private set; }
        public Guid? RepliedId { get; private set; }
        public Content Content { get; private set; } = null!;
        public int LikeCount { get; private set; }
        public int ChildCount { get; private set; }

        private Comment() { }

        public Comment(Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, bool isDeleted, int version, Guid userId, Guid? postId, Guid? parentId, Guid? repliedId, Content content)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
            IsDeleted = isDeleted;
            Version = version;
            UserId = userId;
            PostId = postId;
            ParentId = parentId;
            RepliedId = repliedId;
            Content = content;
        }

    }
}

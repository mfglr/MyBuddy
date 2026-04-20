namespace CommentQueryService.Domain.CommentAggregate
{
    public class Comment(
        Guid id,
        DateTime createdAt,
        DateTime? updatedAt,
        int version,
        Guid userId,
        Guid postId,
        Guid? parentId,
        Guid? repliedId,
        CommentContent content,
        CommentUser user
    )
    {
        public Guid Id { get; private set; } = id;
        public DateTime CreatedAt { get; private set; } = createdAt;
        public DateTime? UpdatedAt { get; private set; } = updatedAt;
        public bool IsDeleted { get; private set; } = false;
        public int Version { get; private set; } = version;
        public Guid UserId { get; private set; } = userId;
        public Guid PostId { get; private set; } = postId;
        public Guid? ParentId { get; private set; } = parentId;
        public Guid? RepliedId { get; private set; } = repliedId;
        public CommentContent Content { get; private set; } = content;
        public IReadOnlyList<int> ProcessedVersions { get; private set; } = [version];
        public CommentUser User { get; private set; } = user;
        public int LikeCount { get; private set; } = 0;
        public int ChildCount { get; private set; } = 0;

        public bool ShouldBeDeleted => IsDeleted && ProcessedVersions.Count == ProcessedVersions.Max();

        public bool TryUpdate(DateTime? updatedAt, bool isDeleted, int version, CommentContent content)
        {
            if (version == Version)
                return false;
            ProcessedVersions = [..ProcessedVersions, version];
            if (version > Version)
            {
                IsDeleted = isDeleted;
                UpdatedAt = updatedAt;
                Version = version;
                Content = content;
            }
            return true;
        }

        public bool TryUpdateUser(CommentUser user)
        {
            if (user.Version <= User.Version)
                return false;

            User = user;
            Version++;
            return true;
        }
    }
}

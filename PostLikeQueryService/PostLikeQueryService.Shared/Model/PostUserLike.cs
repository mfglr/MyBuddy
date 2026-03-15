namespace PostLikeQueryService.Shared.Model
{
    public class PostUserLike
    {
        public Guid SequenceId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public int Version { get; private set; }
        public Guid PostId { get; private set; }
        public Guid UserId { get; private set; }

        private PostUserLike() { }

        public PostUserLike(
            Guid sequenceId,
            DateTime createdAt,
            bool isDeleted,
            DateTime? deletedAt,
            int version,
            Guid postId,
            Guid userId
        )
        {
            SequenceId = sequenceId;
            CreatedAt = createdAt;
            IsDeleted = isDeleted;
            DeletedAt = deletedAt; 
            Version = version;
            PostId = postId;
            UserId = userId;
        }
    }
}

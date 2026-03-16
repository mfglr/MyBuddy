namespace CommentLikeService.Domain
{
    public class CommentLike
    {
        public CommentLikeId Id { get; private set; }
        public Guid SequenceId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public int Version { get; private set; }

        public CommentLike(CommentLikeId id)
        {
            Id = id;
            SequenceId = Guid.CreateVersion7();
            CreatedAt = DateTime.UtcNow;
            DeletedAt = null;
            IsDeleted = false;
            Version = 1;
        }

        public void Like()
        {
            if (!IsDeleted)
                throw new CommentLikeAlreadyAvailableException();

            IsDeleted = false;
            DeletedAt = null;
            Version++;
        }

        public void Dislike()
        {
            if (IsDeleted)
                throw new CommentLikeNotAvailableException();

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            Version++;
        }
    }
}

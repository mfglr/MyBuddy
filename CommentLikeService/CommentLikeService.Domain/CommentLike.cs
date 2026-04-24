namespace CommentLikeService.Domain
{
    public class CommentLike
    {
        public CommentLikeId Id { get; private set; }
        public Guid SequenceId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        internal CommentLike(CommentLikeId id)
        {
            Id = id;
            SequenceId = Guid.CreateVersion7();
            CreatedAt = DateTime.UtcNow;
        }
    }
}

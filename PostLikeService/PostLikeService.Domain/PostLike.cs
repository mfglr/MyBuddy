namespace PostLikeService.Domain
{
    public class PostLike
    {
        public PostLikeId Id { get; private set; }
        public Guid SequenceId { get; private set; } = Guid.CreateVersion7();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        internal PostLike(PostLikeId id) => Id = id;
    }
}

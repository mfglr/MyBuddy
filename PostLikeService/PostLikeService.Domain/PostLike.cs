namespace PostLikeService.Domain
{
    public class PostLike(PostLikeId id)
    {
        public PostLikeId Id { get; private set; } = id;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}

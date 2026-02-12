namespace PostLikeService.Domain
{
    public class PostLikeId(Guid userId, Guid postId)
    {
        public Guid UserId { get; private set; } = userId;
        public Guid PostId { get; private set; } = postId;
    }
}

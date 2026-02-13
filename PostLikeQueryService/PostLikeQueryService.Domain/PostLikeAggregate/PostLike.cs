namespace PostLikeQueryService.Domain.PostLikeAggregate
{
    public class PostLike(Guid userId, Guid postId, int version, DateTime createdAt)
    {
        public Guid Id { get; private set; } = Guid.CreateVersion7();
        public Guid UserId { get; private set; } = userId;
        public Guid PostId { get; private set; } = postId;
        public DateTime CreatedAt { get; private set; } = createdAt;
        public int Version { get; private set; } = version;
        public int ConcurrencyToken { get; private set; }

        public void Upgrade(int version)
        {
            if (version <= Version) return;
            Version = version;
        }

    }
}

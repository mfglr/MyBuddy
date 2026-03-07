namespace PostLikeService.Domain
{
    public class PostLike(PostLikeId id)
    {
        public PostLikeId Id { get; private set; } = id;
        public int Version { get; private set; } = 1;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public bool IsDeleted { get; private set; } = false;
        public DateTime? DeletedAt { get; private set; }

        public void Dislike()
        {
            if(IsDeleted)
                throw new PostNotLikedBeforeException();
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            Version++;
        }

        public void Like()
        {
            if (!IsDeleted)
                throw new PostAlreadyLikedException();
            IsDeleted = false;
            DeletedAt = null;
            Version++;
        }
    }
}

namespace PostLikeService.Domain
{
    public class PostLike(PostLikeId id)
    {
        public PostLikeId Id { get; private set; } = id;
        public int Version { get; private set; } = 1;
        public bool IsDeleted { get; private set; } = false;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public void Dislike()
        {
            if(IsDeleted)
                throw new PostNotLikedBeforeException();
            IsDeleted = true;
            Version++;
        }

        public void Like()
        {
            if (!IsDeleted)
                throw new PostAlreadyLikedException();
            IsDeleted = false;
            Version++;
        }
    }
}

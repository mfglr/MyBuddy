namespace CommentLikeQueryService.Domain.CommentLikeAggregate
{
    public class CommentLike(CommentLikeId id, DateTime createdAt, CommentLikeUser user)
    {
        public CommentLikeId Id { get; private set; } = id;
        public DateTime CreatedAt { get; private set; } = createdAt;
        public CommentLikeUser User { get; private set; } = user;

        public bool TryUpdateUser(CommentLikeUser user)
        {
            if (user.Version <= User.Version)
                return false;
            User = user;
            return true;
        }
    }
}

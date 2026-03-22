namespace CommentLikeQueryService.Domain
{
    public class CommentLikeProjection(ProjectionId id, CommentLike commentLike, User user)
    {
        public ProjectionId Id { get; private set; } = id;
        public int Version { get; private set; } = 1;
        public CommentLike CommentLike { get; private set; } = commentLike;
        public User User { get; private set; } = user;

        public void UpdateCommentLike(CommentLike commentLike)
        {
            if (commentLike.Version <= CommentLike.Version)
                throw new OutdatedVersionException();

            CommentLike = commentLike;
            Version++;
        }

        public void UpdateUser(User user)
        {
            if (user.Version <= User.Version)
                throw new OutdatedVersionException();

            User = user;
            Version++;
        }
    }
}

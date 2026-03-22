namespace CommentQueryService.Domain
{
    public class CommentProjection(Guid id, Comment comment, User user)
    {
        public Guid Id { get; private set; } = id;
        public int Version { get; private set; } = 1;
        public Comment Comment { get; private set; } = comment;
        public User User { get; private set; } = user;
        public int LikeCount { get; private set; } = 0;
        public int ChildCount { get; private set; } = 0;

        public void UpdateComment(Comment comment)
        {
            if (comment.Version <= Comment.Version)
                throw new OutdatedVersionException();

            Comment = comment;
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

namespace PostQueryService.Domain.PostProjectionAggregate
{
    public class PostProjection(Guid id, Guid userId, Post post, PostProjectionUser user)
    {
        public Guid Id { get; private set; } = id;
        public Guid UserId { get; private set; } = userId;
        public Post Post { get; private set; } = post;
        public PostProjectionUser User { get; private set; } = user;


        public bool TryUpdatePost(Post post)
        {
            if (post.Version <= Post.Version)
                return false;
            Post = post;
            return true;
        }

        public bool TryUpdateUser(PostProjectionUser user)
        {
            if(user.Version <= User.Version)
                return false;
            User = user;
            return true;
        }
    }
}

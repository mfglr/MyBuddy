namespace PostQueryService.Domain
{
    public class PostProjection
    {
        public string Id { get; private set; }
        public object? Version { get; set; }
        public Post Post { get; private set; }
        public User? User { get; private set; }
        public bool Readable { get; private set; }

        public PostProjection(string id, Post post, User user)
        {
            Id = id;
            Post = post;
            User = user;
            Readable = true;
        }

        public PostProjection(string id, Post post)
        {
            Id = id;
            Post = post;
            Readable = false;
        }

        private void Update()
        {
            Readable = User != null && !Post.IsDeleted;
        }

        public void UpdateUser(User user)
        {
            if (User != null && User.Version >= user.Version)
                throw new VersionOutdatedException();

            User = user;
            Update();
        }

        public void UpdatePost(Post post)
        {
            if (Post != null && Post.Version >= post.Version)
                throw new VersionOutdatedException();

            Post = post;
            Update();
        }
    }
}

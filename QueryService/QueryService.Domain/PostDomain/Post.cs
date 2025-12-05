namespace QueryService.Domain.PostDomain
{
    public class Post
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public byte[] RowVersion { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Content? Content { get; private set; }
        public IReadOnlyList<Media> Media { get; private set; }

        public bool IsValidVersion => !Media.Any(x => !x.IsValidVersion);

        private Post(){}

        public Post(Guid id, int version, Content? content, IEnumerable<Media> media)
        {
            Id = id;
            Version = version;
            Content = content;
            Media = [..media];
        }

        public void Create()
        {
            CreatedAt = DateTime.UtcNow;
        }
        
        public void Update(Post next)
        {
            if (!IsValidVersion || next.Version <= Version) return;

            Version = next.Version;
            Content = next.Content;
            Media = [.. next.Media];
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

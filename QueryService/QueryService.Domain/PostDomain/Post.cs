namespace QueryService.Domain.PostDomain
{
    public class Post
    {
        public readonly static string MediaContainerName = "PostMedia";

        public Guid Id { get; private set; }
        public byte[] RowVersion { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Content? Content { get; private set; }
        public IReadOnlyList<Media> Media { get; private set; }
        
        private Post(){}

        public Post(Guid id, Content? content, IEnumerable<Media> media)
        {
            Id = id;
            Content = content;
            Media = [..media];
        }

        public void Create()
        {
            CreatedAt = DateTime.UtcNow;
        }
        
        public void DeleMedia(string blobName)
        {
            Media = [.. Media.Where(x => x.BlobName != blobName)];
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

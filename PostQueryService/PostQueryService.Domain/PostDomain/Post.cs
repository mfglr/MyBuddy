using System.Text.Json;

namespace PostQueryService.Domain.PostDomain
{
    public class Post
    {
        public byte[] RowVersion { get; private set; } = null!;

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public int Version { get; private set; }
        public Guid UserId { get; private set; }
        public Content? Content { get; private set; }
        public string Media { get; private set; } = null!;

        private Post() { }

        public Post(Guid id, DateTime createdAt, DateTime? updatedAt, int version, Guid userId, Content? content, IEnumerable<PostMedia> media)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Version = version;
            UserId = userId;
            Content = content;
            Media = JsonSerializer.Serialize(media);
        }

        public void Set(DateTime? updatedAt, int version, Content? content, IEnumerable<PostMedia> media)
        {
            if (version <= Version)
                return;

            UpdatedAt = updatedAt;
            Version = version;
            Content = content;
            Media = JsonSerializer.Serialize(media);
        }
    }
}

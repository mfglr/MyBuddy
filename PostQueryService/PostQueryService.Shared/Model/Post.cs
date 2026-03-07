using System.Text.Json;

namespace PostQueryService.Shared.Model
{
    public class Post
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public int Version { get; private set; }
        public Guid UserId { get; private set; }
        public Content? Content { get; private set; }
        public string Media { get; private set; } = null!;
        public int LikeCount { get; private set; }
        public int CommentCount { get; private set; }

        private Post(){}

        public Post(Guid id, DateTime createdAt, DateTime? updatedAt, int version, Guid userId, Content? content, IEnumerable<Media> media)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Version = version;
            UserId = userId;
            Content = content;
            Media = JsonSerializer.Serialize(media);
            LikeCount = 0;
            CommentCount = 0;
        }

        public void Update(int version)
        {
            Version = version;
        }
    }
}

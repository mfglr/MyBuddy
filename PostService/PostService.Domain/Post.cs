using System.Text.Json.Serialization;

namespace PostService.Domain
{
    public class Post
    {
        public readonly static int MaxMediaLength = 5;
        public readonly static string MediaContainerName = "PostMedia";

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public int Version { get; private set; }
        public Content? Content { get; private set; }
        public int NumberOfMedia { get; private set; }

        [JsonConstructor]
        private Post(Guid id, DateTime createdAt, DateTime? updatedAt, int version, Content? content, int numberOfMedia)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Version = version;
            Content = content;
            NumberOfMedia = numberOfMedia;
        }

        public Post(Content? content, int numberOfMedia)
        {
            if (content == null && numberOfMedia == 0)
                throw new Exception("Post content exception.");

            if (numberOfMedia > MaxMediaLength)
                throw new Exception("Post media exception.");

            Content = content;
            NumberOfMedia = numberOfMedia;
        }

        public void Create()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Version = 0;
        }

        public void SetContentModerationResult(ModerationResult result)
        {
            Version++;
            Content = Content?.SetModerationResult(result);
        }
    }
}

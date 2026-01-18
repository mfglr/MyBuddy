using Shared.Objects;

namespace QueryService.Domain.PostDomain
{
    public class Post
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Guid UserId { get; private set; }
        public int Version { get; private set; }
        public PostContent? Content { get; private set; }
        public List<Media> Media { get; private set; } = [];
        public long ReadVersion { get; private set; }

        public bool IsValidVersion => !Media.Any(x => x.ModerationResult == null);

        private Post() { }

        public Post(Guid id,DateTime createdAt, DateTime? updatedAt, Guid userId, int version, PostContent? content, IEnumerable<Media> media)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            UserId = userId;
            Version = version;
            Content = content;
            Media = [.. media];
            ReadVersion = 1;
        }

        public void Set(int version, DateTime? updatedAt, PostContent? content, IEnumerable<Media> media)
        {
            UpdatedAt = updatedAt;
            Version = version;
            Content = content;
            Media = [..media];
            ReadVersion++;
        }
    }
}

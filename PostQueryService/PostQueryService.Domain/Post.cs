namespace PostQueryService.Domain
{
    public class Post(
        DateTime createdAt,
        DateTime? updatedAt,
        DateTime? deletedAt,
        bool isDeleted,
        int version,
        Content? content,
        IReadOnlyList<Media.Models.Media> media
    )
    {
        public DateTime CreatedAt { get; private set; } = createdAt;
        public DateTime? UpdatedAt { get; private set; } = updatedAt;
        public DateTime? DeletedAt { get; private set; } = deletedAt;
        public bool IsDeleted { get; private set; } = isDeleted;
        public int Version { get; private set; } = version;
        public Content? Content { get; private set; } = content;
        public IReadOnlyList<Media.Models.Media> Media { get; private set; } = media;
    }
}

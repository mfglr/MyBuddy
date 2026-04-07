using System.Text.Json.Serialization;

namespace PostQueryService.Domain.PostProjectionAggregate
{
    public class PostProjection
    {
        public string Id { get; private set; }
        public string UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? SoftDeletedAt { get; private set; }
        public int Version { get; private set; }
        public PostContent? Content { get; private set; }
        public IReadOnlyList<PostQueryMedia> Media { get; private set; }
        public IReadOnlyList<int> ProcessedVersions { get; private set; }
        public PostProjectionUser User { get; private set; }

        [JsonConstructor]
        private PostProjection(
            string id,
            string userId,
            DateTime createdAt,
            DateTime? updatedAt,
            DateTime? softDeletedAt,
            int version,
            PostContent? content,
            IReadOnlyList<PostQueryMedia> media,
            IReadOnlyList<int> processedVersions,
            PostProjectionUser user
        )
        {
            Id = id;
            UserId = userId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            SoftDeletedAt = softDeletedAt;
            Version = version;
            Content = content;
            Media = media;
            ProcessedVersions = processedVersions;
            User = user;
        }

        public PostProjection(
            string id,
            string userId,
            DateTime createdAt,
            DateTime? updatedAt,
            DateTime? softDeletedAt,
            int version,
            PostContent? content,
            IReadOnlyList<PostQueryMedia> media,
            PostProjectionUser user
    )
        {
            Id = id;
            UserId = userId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            SoftDeletedAt = softDeletedAt;
            Version = version;
            Content = content;
            Media = media;
            ProcessedVersions = [version];
            User = user;
        }

        public bool IsAllEventsProcessed() => ProcessedVersions.Max() == ProcessedVersions.Count;


        public bool TryUpdatePost(
            DateTime? updatedAt,
            DateTime? softDeletedAt,
            int version,
            PostContent? content,
            IReadOnlyList<PostQueryMedia> media
        )
        {
            if (version == Version)
                return false;
            
            ProcessedVersions = [..ProcessedVersions, version];
            if(version > Version)
            {
                UpdatedAt = updatedAt;
                SoftDeletedAt = softDeletedAt;
                Version = version;
                Content = content;
                Media = media;
            }
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

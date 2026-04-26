using System.Text.Json.Serialization;

namespace PostQueryService.Domain.PostProjectionAggregate
{
    [method: JsonConstructor]
    public class PostProjection(
        string id,
        string userId,
        DateTime createdAt,
        DateTime? updatedAt,
        bool isDeleted,
        int version,
        PostContent? content,
        IReadOnlyList<PostQueryMedia> media,
        PostProjectionUser user
        )
    {
        public string Id { get; private set; } = id;
        public string UserId { get; private set; } = userId;
        public DateTime CreatedAt { get; private set; } = createdAt;
        public DateTime? UpdatedAt { get; private set; } = updatedAt;
        public bool IsDeleted { get; private set; } = isDeleted;
        public int Version { get; private set; } = version;
        public PostContent? Content { get; private set; } = content;
        public IReadOnlyList<PostQueryMedia> Media { get; private set; } = media;
        public PostProjectionUser User { get; private set; } = user;

        public bool TryUpdatePost(
            DateTime? updatedAt,
            bool isDeleted,
            int version,
            PostContent? content,
            IReadOnlyList<PostQueryMedia> media
        )
        {
            if (version <= Version)
                return false;

            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
            Version = version;
            Content = content;
            Media = media;
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

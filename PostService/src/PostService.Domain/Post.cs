using PostService.Domain.Exceptions;
using Shared.Events.SharedObjects;

namespace PostService.Domain
{
    public class Post
    {
        public readonly static int MaxMediaCount = 5;
        public readonly static string MediaContainerName = "PostMedia";

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Guid UserId { get; private set; }
        public bool IsDeleted { get; private set; }
        public int Version { get; private set; }
        public Content? Content { get; private set; }
        public IReadOnlyList<Media> Media { get; private set; }

        public bool IsValidVersion =>
            (
                Content == null ||
                Content.ModerationResult != null
            ) &&
            !Media.Any(x => !x.IsValid);


        public Post(Guid userId, Content? content, IReadOnlyList<Media> media)
        {
            if (!media.Any())
                throw new PostMediaRequiredException();

            if (media.Count > MaxMediaCount)
                throw new PostMediaCountException();

            if (media.Any(x => x.ContainerName != MediaContainerName))
                throw new InvalidContainerName();

            Id = Guid.CreateVersion7();
            UserId = userId;
            Content = content;
            CreatedAt = DateTime.UtcNow;
            Version = 1;
            Media = media;
        }

        public void Delete()
        {
            if (IsDeleted)
                throw new PostNotFoundException();

            IsDeleted = true;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void Restore()
        {
            if (!IsDeleted)
                throw new PostAlreadyAvailableException();

            IsDeleted = false;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdateContent(Content content)
        {
            if (!IsDeleted)
                throw new PostNotFoundException();

            Content = content;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void SetContentModerationResult(ModerationResult moderationResult)
        {
            if (IsDeleted)
                throw new PostNotFoundException();

            if (Content == null)
                throw new PostContentNotAvailableException();
            Content = Content.SetModerationResult(moderationResult);
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void SetMedia(
            string blobName,
            Metadata metadata,
            ModerationResult? moderationResult,
            IEnumerable<Thumbnail> thumbnails,
            string? transcodedBlobName
        )
        {
            if (IsDeleted)
                throw new PostNotFoundException();

            var media = Media.FirstOrDefault(x => x.BlobName == blobName) ?? throw new PostMediaNotFoundException();
            media.Set(metadata,moderationResult,thumbnails,transcodedBlobName);
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
    }
}

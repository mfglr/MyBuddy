using Media.Models;
using PostService.Domain.Exceptions;

namespace PostService.Domain
{
    public class Post
    {
        public readonly static int MaxMediaCount = 5;
        public readonly static string MediaContainerName = "PostMedia";

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? SoftDeletedAt { get; private set; }
        public Guid UserId { get; private set; }
        public int Version { get; private set; }
        public Content? Content { get; private set; }
        public IReadOnlyList<PostMedia> Media { get; private set; }
        
        private bool IsSoftDeleted => SoftDeletedAt != null;


        public Post(Guid userId, Content? content, IEnumerable<PostMedia> media)
        {
            if (!media.Any())
                throw new PostMediaRequiredException();

            if (media.Count() > MaxMediaCount)
                throw new PostMediaCountException();

            if (media.Any(x => x.ContainerName != MediaContainerName))
                throw new InvalidContainerName();

            Id = Guid.CreateVersion7();
            UserId = userId;
            Content = content;
            CreatedAt = DateTime.UtcNow;
            Version = 1;
            Media = [.. media];
        }

        public void Delete()
        {
            if (IsSoftDeleted)
                throw new PostNotFoundException();

            SoftDeletedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void Restore()
        {
            if (!IsSoftDeleted)
                throw new PostAlreadyAvailableException();

            SoftDeletedAt = null;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void UpdateContent(Content content)
        {
            if (IsSoftDeleted)
                throw new PostNotFoundException();

            Content = content;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void SetContentModerationResult(ModerationResult moderationResult)
        {
            if (IsSoftDeleted)
                throw new PostNotFoundException();

            if (Content == null)
                throw new PostContentNotAvailableException();
            Content = Content.SetModerationResult(moderationResult);
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void SetMedia(
            string blobName,
            MediaProcessingContext context
        )
        {
            if (IsSoftDeleted)
                throw new PostNotFoundException();

            var media =
                Media.FirstOrDefault(x => x.BlobName == blobName) ??
                throw new PostMediaNotFoundException();
            
            Media = [.. Media.Select(x => x == media ? media.Set(context) : x)];
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
    }
}

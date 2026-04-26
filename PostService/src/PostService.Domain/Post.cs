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
        public bool IsDeleted { get; private set; }
        public int Version { get; private set; }
        public Guid UserId { get; private set; }
        public Content? Content { get; private set; }
        public IReadOnlyList<PostMedia> Media { get; private set; }

        public IEnumerable<string> BlobNames => Media.SelectMany(x => x.BlobNames);
        public bool ShouldBeDeleted =>
            IsDeleted &&
            (Content == null || Content.ModerationResult != null) &&
            !Media.Any(x => x.Context.Metadata == null);

        public Post(Guid userId, Content? content, IEnumerable<PostMedia> media)
        {
            if (!media.Any())
                throw new PostMediaRequiredException();

            if (media.Count() > MaxMediaCount)
                throw new PostMediaCountException();

            if (media.Any(x => x.ContainerName != MediaContainerName))
                throw new InvalidContainerName();

            Id = Guid.CreateVersion7();
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
            Version = 1;
            UserId = userId;
            Content = content;
            Media = [.. media];
        }

        public void Delete()
        {
            if (IsDeleted)
                throw new PostNotFoundException();
            IsDeleted = true;
            Version++;
        }

        public void UpdateContent(Content content)
        {
            if (IsDeleted)
                throw new PostNotFoundException();

            Content = content;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void SetContentModerationResult(ModerationResult moderationResult)
        {
            if (Content == null)
                throw new PostContentNotAvailableException();
            Content = Content.SetModerationResult(moderationResult);
            Version++;
        }

        public void SetMedia(string blobName, MediaProcessingContext context)
        {
            var media =
                Media.FirstOrDefault(x => x.BlobName == blobName) ??
                throw new PostMediaNotFoundException();
            Media = [.. Media.Select(x => x == media ? media.Set(context) : x)];
            Version++;
        }
    }
}

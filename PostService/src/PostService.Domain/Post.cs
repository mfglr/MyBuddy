using Newtonsoft.Json;
using Orleans;
using PostService.Domain.Exceptions;

namespace PostService.Domain
{
    [GenerateSerializer]
    [Alias("PostService.Domain.Post")]
    public class Post
    {
        public readonly static int MaxMediaCount = 5;
        public readonly static string MediaContainerName = "PostMedia";

        [Id(0)]
        public Guid Id { get; private set; }
        [Id(1)]
        public DateTime CreatedAt { get; private set; }
        [Id(2)]
        public DateTime? UpdatedAt { get; private set; }
        [Id(3)]
        public Guid UserId { get; private set; }
        [Id(4)]
        public bool IsDeleted { get; private set; }
        [Id(5)]
        public int Version { get; private set; }
        [Id(6)]
        public Content? Content { get; private set; }
        [Id(7)]
        public List<Media> Media { get; private set; }

        public bool IsPreprocessingCompletedAndIsValid() =>
            !Media.Any(x => !x.IsPreprocessingCompletedAndIsValid()) &&
            Content != null && Content.IsPreprocessingCompletedAndIsValid();

        [JsonConstructor]
        public Post(Guid id, DateTime createdAt, DateTime? updatedAt, Guid userId, bool isDeleted, int version, Content? content, List<Media> media)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            UserId = userId;
            IsDeleted = isDeleted;
            Version = version;
            Content = content;
            Media = media;
        }

        public Post(Guid userId, Content? content, List<Media> media)
        {
            if (media.Count <= 0)
                throw new PostMediaRequiredException();

            if (media.Count > MaxMediaCount)
                throw new PostMediaCountException();

            if (media.Any(x => x.ContainerName != MediaContainerName))
                throw new InvalidContainerName();

            Id = Guid.CreateVersion7();
            UserId = userId;
            Content = content;
            Media = media;
            CreatedAt = DateTime.UtcNow;
            Version = 1;
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

        public void SetContentModerationResult(ModerationResult result)
        {
            if (IsDeleted)
                throw new PostNotFoundException();

            Content = Content?.SetModerationResult(result);
            UpdatedAt = DateTime.UtcNow;
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

        public void SetMediaTranscodedBlobName(string blobName, string transcodedBlobName)
        {
            if (IsDeleted)
                throw new PostNotFoundException();

            var media =
                Media.FirstOrDefault(x => x.BlobName == blobName) ??
                throw new PostMediaNotFoundException();

            media.SetTranscodedBlobName(transcodedBlobName);
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void SetMediaMetadata(string blobName, Metadata metadata)
        {
            if (IsDeleted)
                throw new PostNotFoundException();

            var media =
                Media.FirstOrDefault(x => x.BlobName == blobName) ??
                throw new PostMediaNotFoundException();

            media.SetMetadata(metadata);
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void SetMediaModerationResult(string blobName, ModerationResult result)
        {
            if (IsDeleted)
                throw new PostNotFoundException();

            var media =
                Media.FirstOrDefault(x => x.BlobName == blobName) ??
                throw new PostMediaNotFoundException();

            media.SetModerationResult(result);
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
        public void AddThumbnail(string blobName, Thumbnail thumbnail)
        {
            if (IsDeleted)
                throw new PostNotFoundException();

            var media =
                Media.FirstOrDefault(x => x.BlobName == blobName) ??
                throw new PostMediaNotFoundException();
            media.AddThumbnail(thumbnail);
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
       
    }
}

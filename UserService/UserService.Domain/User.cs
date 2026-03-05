using Shared.Events.SharedObjects;

namespace UserService.Domain
{
    public class User(Guid id, UserName userName)
    {
        public static readonly string MediaContainerName = "UserMedia";

        public Guid Id { get; private set; } = id;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        public int Version { get; private set; } = 1;
        public bool IsDeleted { get; private set; } = false;
        public Name? Name { get; private set; }
        public UserName UserName { get; private set; } = userName;
        public Gender Gender { get; private set; } = Gender.Unknown();
        public IReadOnlyList<Media> Media { get; private set; } = [];
        public bool IsValidVersion => !Media.Any(m => !m.IsValid);

        public void UpdateName(Name name)
        {
            if (IsDeleted)
                throw new UserNotFoundException();
            Name = name;

            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void UpdateUserName(UserName userName)
        {
            if (IsDeleted)
                throw new UserNotFoundException();
            UserName = userName;

            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void CreateMedia(Media media)
        {
            if (IsDeleted)
                throw new UserNotFoundException();
            if(media.Type != MediaType.Image)
                throw new InvalidMediaTypeException();
            Media = [media, .. Media];
            
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public Media DeleteMedia(string blobName)
        {
            if (IsDeleted)
                throw new UserNotFoundException();
            var media = Media.FirstOrDefault(x => x.BlobName == blobName) ?? throw new MediaNotFoundException();
            Media = [.. Media.Where(x => x != media)];

            UpdatedAt = DateTime.UtcNow;
            Version++;

            return media;
        }

        public void UpdateGender(Gender gender)
        {
            if (IsDeleted)
                throw new UserNotFoundException();
            Gender = gender;

            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void SetMedia(
            string blobName,
            Metadata? metadata,
            ModerationResult? moderationResult,
            IEnumerable<Thumbnail> thumbnails
        )
        {
            var media = Media.FirstOrDefault(m => m.BlobName == blobName) ?? throw new MediaNotFoundException();
            media.Set(metadata, moderationResult, thumbnails);

            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
    }
}

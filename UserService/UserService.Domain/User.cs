using Newtonsoft.Json;

namespace UserService.Domain
{
    [GenerateSerializer]
    [Alias("UserService.Domain.User")]
    public class User
    {
        public static readonly string MediaContainerName = "UserMedia";

        [Id(0)]
        public Guid Id { get; private set; }
        [Id(1)]
        public DateTime CreatedAt { get; private set; }
        [Id(2)]
        public DateTime? UpdatedAt { get; private set; }
        [Id(3)]
        public int Version { get; private set; } = 1;
        [Id(4)]
        public bool IsDeleted { get; private set; }
        [Id(5)]
        public Name? Name { get; private set; }
        [Id(6)]
        public UserName UserName { get; private set; }
        [Id(7)]
        public Gender Gender { get; private set; }
        [Id(8)]
        public List<Media> Media { get; private set; }


        public User(Guid id, UserName userName)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
            UserName = userName;
            Gender = Gender.Unknown();
            IsDeleted = false;
            Media = [];
        }

        [JsonConstructor]
        public User(Guid id, DateTime createdAt, DateTime? updatedAt, int version, bool isDeleted, Name? name, UserName userName, Gender gender, List<Media> media)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Version = version;
            IsDeleted = isDeleted;
            Name = name;
            UserName = userName;
            Gender = gender;
            Media = media;
        }

        public bool IsPreprocessingCompleted() => !Media.Any(m => !m.IsPreprocessingCompleted());

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

            Media.FirstOrDefault(x => x.IsActive)?.Inactivate();
            media.Activate();
            Media.Add(media);
            
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void SetMediaMetadata(string blobName, Metadata metadata)
        {
            if (IsDeleted)
                throw new UserNotFoundException();
            
            var media = Media.FirstOrDefault(m => m.BlobName == blobName) ?? throw new MediaNotFoundException();
            media.SetMetadata(metadata);
            
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void UpdateGender(Gender gender)
        {
            if (IsDeleted)
                throw new UserNotFoundException();
            Gender = gender;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }


        public void SetMediaModerationResult(string blobName, ModerationResult moderationResult)
        {
            if (IsDeleted)
                throw new UserNotFoundException();
            
            var media = Media.FirstOrDefault(m => m.BlobName == blobName) ?? throw new MediaNotFoundException();
            media.SetModerationResult(moderationResult);
            
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void AddMediaThumbnail(string blobName, Thumbnail thumbnail)
        {
            if (IsDeleted)
                throw new UserNotFoundException();
            
            var media = Media.FirstOrDefault(m => m.BlobName == blobName) ?? throw new MediaNotFoundException();
            media.AddThumbnail(thumbnail);
            
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
    }
}

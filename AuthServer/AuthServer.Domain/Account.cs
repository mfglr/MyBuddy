using Media.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthServer.Domain
{
    public class Account : IdentityUser
    {
        public static readonly string MediaContainerName = "UserMedia";

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public int Version { get; private set; }
        public Name? Name { get; private set; }
        public Gender Gender { get; private set; } = null!;
        public IReadOnlyList<AccountMedia> Media { get; private set; } = null!;

        private Account() { }

        internal Account(Email email) : base()
        {
            Id = Guid.CreateVersion7().ToString();
            CreatedAt = DateTime.UtcNow;
            Version = 1;
            Email = email.Value;
            UserName = email.GenerateUserName();
            Gender = Gender.Unknown();
            Media = [];
        }

        internal void UpdateEmail(Email email)
        {
            Email = email.Value;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        internal void UpdateUserName(UserName userName)
        {
            UserName = userName.Value;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void UpdateName(Name name)
        {
            Name = name;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void UpdateGender(Gender gender)
        {
            Gender = gender;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void CreateMedia(AccountMedia media)
        {
            if (media.Context.Type != MediaType.Image)
                throw new InvalidMediaTypeException();

            Media = [media, .. Media];
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }

        public void SetMedia(string blobName,MediaProcessingContext context)
        {
            var media = Media.FirstOrDefault(m => m.BlobName == blobName) ?? throw new MediaNotFoundException();
            Media = [.. Media.Select(x => x == media ? media.Set(context) : x)];
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
    }
}

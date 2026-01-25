using Shared.Objects;

namespace UserService.Domain
{
    public class User
    {
        public static readonly string MediaContainerName = "UserMedia";

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public int Version { get; private set; }
        public bool IsDeleted { get; private set; }
        public Name? Name { get; private set; }
        public Username Username { get; private set; }
        public Gender Gender { get; private set; }
        public IReadOnlyList<Media> Media { get; private set; }

        public User(Guid id, Username username)
        {
            Id = id;
            Username = username;
            Media = [];
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
            Version = 1;
            Gender = Gender.Unknown();
        }

        public void UpdateName(Name name)
        {
            if (IsDeleted)
                throw new UserNotFoundException();

            Name = name;
            UpdatedAt = DateTime.UtcNow;
            Version++;
        }
    }
}

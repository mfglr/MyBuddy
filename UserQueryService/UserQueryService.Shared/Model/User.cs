namespace UserQueryService.Shared.Model
{
    public class User(
        Guid id,
        DateTime createdAt,
        DateTime? updatedAt,
        DateTime? deletedAt,
        bool isDeleted,
        int version,
        string? name,
        string userName,
        string gender,
        IEnumerable<Media.Models.Media> media
    )
    {
        public Guid Id { get; private set; } = id;
        public DateTime CreatedAt { get; private set; } = createdAt;
        public DateTime? UpdatedAt { get; private set; } = updatedAt;
        public DateTime? DeletedAt { get; private set; } = deletedAt;
        public bool IsDeleted { get; private set; } = isDeleted;
        public int Version { get; private set; } = version;
        public string? Name { get; private set; } = name;
        public string UserName { get; private set; } = userName;
        public string Gender { get; private set; } = gender;
        public IReadOnlyList<Media.Models.Media> Media { get; private set; } = [..media];
        public int PostCount { get; private set; } = 0;
    }
}

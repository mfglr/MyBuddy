using System.Text.Json;

namespace PostQueryService.Domain.UserDomain
{
    public class User
    {

        public byte[] RowVersion { get; private set; } = null!;

        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public string? Name { get; private set; }
        public string UserName { get; private set; }
        public string? Media { get; private set; }

        private User() { }

        public User(Guid id, int version, string? name, string userName, UserMedia? media)
        {
            Id = id;
            Version = version;
            Name = name;
            UserName = userName;
            Media = media != null ? JsonSerializer.Serialize(media) : null;
        }

        public void Set(int version, string? name, string userName, UserMedia? media)
        {
            Version = version;
            Name = name;
            UserName = userName;
            Media = media != null ? JsonSerializer.Serialize(media) : null;
        }
    }
}

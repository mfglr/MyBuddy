using System.Text.Json;

namespace PostLikeQueryService.Domain.UserAggregate
{
    public class User
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public string? Name { get; private set; }
        public string UserName { get; private set; }
        public string? Media { get; private set; }
        public int ConcurrencyToken { get; private set; }

        private User(Guid id, int version, string? name, string userName, string media)
        {
            Id = id;
            Version = version;
            Name = name;
            UserName = userName;
            Media = media;
        }

        public User(Guid id, int version, string? name, string userName, Media? media)
        {
            Id = id;
            Version = version;
            Name = name;
            UserName = userName;
            Media = media != null ? JsonSerializer.Serialize(media) : null;
            ConcurrencyToken = 1;
        }

        public void Upgrade(int version, string? name, string userName, Media? media)
        {
            if (version <= Version)
                return;

            Version = version;
            Name = name;
            UserName = userName;
            Media = media != null ? JsonSerializer.Serialize(media) : null;
            ConcurrencyToken++;
        }
    }
}

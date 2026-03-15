namespace PostLikeQueryService.Shared.Model
{
    public class User
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public string? Name { get; private set; }
        public string UserName { get; private set; } = null!;
        public Media? Media { get; private set; }

        public User(){}

        public User(Guid id, int version, string? name, string userName, Media? media)
        {
            Id = id;
            Version = version;
            Name = name;
            UserName = userName;
            Media = media;
        }
    }
}

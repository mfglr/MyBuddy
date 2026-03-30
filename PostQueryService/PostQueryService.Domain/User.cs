namespace PostQueryService.Domain
{
    public class User(string id, int version, string? name, string userName, Media.Models.Media? media)
    {
        public string Id { get; private set; } = id;
        public int Version { get; private set; } = version;
        public string? Name { get; private set; } = name;
        public string UserName { get; private set; } = userName;
        public Media.Models.Media? Media { get; private set; } = media;
    }
}

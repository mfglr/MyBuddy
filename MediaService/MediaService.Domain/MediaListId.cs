namespace MediaService.Domain
{
    public class MediaListId(Guid id, string containerName)
    {
        public Guid Id { get; private set; } = id;
        public string ContainerName { get; private set; } = containerName;
    }
}

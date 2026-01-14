namespace Shared.Events.MediaService
{
    public record MediaDeletedEvent(string ContainerName, IEnumerable<string> BlobNames);
}

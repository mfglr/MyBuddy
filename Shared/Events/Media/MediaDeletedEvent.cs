namespace Shared.Events.Media
{
    public record MediaDeletedEvent(string ContainerName, IEnumerable<string> BlobNames);
}

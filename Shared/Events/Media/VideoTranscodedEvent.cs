namespace Shared.Events.Media
{
    public record VideoTranscodedEvent(Guid Id, string BlobName);
}

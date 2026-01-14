namespace Shared.Events.MediaService
{
    public record VideoTranscodedEvent(Guid Id, string BlobName);
}

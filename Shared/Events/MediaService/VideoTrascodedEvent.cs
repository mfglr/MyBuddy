namespace Shared.Events.MediaService
{
    public record VideoTrascodedEvent(
        string ContainerName,
        string BlobName,
        string TranscodedBlobName
    );
}

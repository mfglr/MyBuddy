namespace Shared.Events.MediaService
{
    public record VideoTrascodedEvent(
        Guid Id,
        string ContainerName,
        string BlobName,
        string TranscodedBlobName
    );
}

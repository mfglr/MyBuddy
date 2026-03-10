namespace Shared.Events.MediaService
{
    public record ExtractMediaMetadataMessage(
        string ContainerName,
        string BlobName
    );
}

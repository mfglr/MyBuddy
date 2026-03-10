using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record VideoTrascodedEvent(
        string ContainerName,
        string BlobName,
        Transcoding Transcoding
    );
}

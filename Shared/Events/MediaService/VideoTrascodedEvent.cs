using Media.Models;

namespace Shared.Events.MediaService
{
    public record VideoTrascodedEvent(
        string ContainerName,
        string BlobName,
        Transcoding Transcoding
    );
}

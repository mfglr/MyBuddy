using Media.Models;

namespace Shared.Events.MediaService
{
    public record MediaMetadataExtractedEvent(
        string ContainerName,
        string BlobName,
        Metadata Metadata
    );
}

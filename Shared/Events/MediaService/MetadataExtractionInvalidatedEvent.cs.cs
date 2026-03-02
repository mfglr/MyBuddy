using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record MetadataExtractionInvalidatedEvent(
        string ContainerName,
        string BlobName,
        Metadata Metadata
    );
}

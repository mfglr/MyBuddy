using Shared.Events.SharedObjects;

namespace Shared.Events.MediaService
{
    public record MetadataExtractionInvalidatedEvent(
        Guid Id,
        string ContainerName,
        string BlobName,
        Metadata Metadata
    );
}

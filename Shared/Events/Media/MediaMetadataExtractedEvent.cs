using Shared.Objects;

namespace Shared.Events.Media
{
    public record MediaMetadataExtractedEvent(Guid Id, string ContainerName, string BlobName, MediaType Type, Metadata Metadata);
}

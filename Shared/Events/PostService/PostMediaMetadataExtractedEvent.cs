using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostMediaMetadataExtractedEvent(Guid Id, string ContainerName, string BlobName, MediaType Type, Metadata Metadata);
}

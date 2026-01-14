using Shared.Objects;

namespace Shared.Events.MediaService
{
    public record MediaCreatedEvent(Guid Id, Guid OwnerId, string ContainerName, string BlobName, MediaType Type);
}

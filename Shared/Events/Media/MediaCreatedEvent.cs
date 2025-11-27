using Shared.Objects;

namespace Shared.Events.Media
{
    public record MediaCreatedEvent(Guid Id, Guid OwnerId, string ContainerName, string BlobName, MediaType Type);
}

using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostMediaCreatedEvent(Guid Id, string ContainerName, string BlobName, MediaType Type);
}

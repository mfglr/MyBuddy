using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostCreatedEvent_Media(string ContainerName, string BlobName, MediaType Type);
    public record PostCreatedEvent(Guid Id, string? Content, IReadOnlyList<PostCreatedEvent_Media> Media);
}

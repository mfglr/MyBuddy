using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostCreatedEvent_Content(string Value);
    public record PostCreatedEvent_Media(
        string ContainerName,
        string BlobName,
        MediaType Type
    );
    public record PostCreatedEvent(
        Guid Id,
        PostCreatedEvent_Content? Content,
        IReadOnlyList<PostCreatedEvent_Media> Media
    );
}

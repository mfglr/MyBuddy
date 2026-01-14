using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostCreatedEvent_Content(string Value);
    public record PostCreatedEvent(
        Guid Id,
        PostCreatedEvent_Content? Content,
        IReadOnlyList<Media> Media
    );
}

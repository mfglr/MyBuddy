using Shared.Objects;

namespace Shared.Events.PostService
{
    public record PostMediaCreatedEvent(
        Guid Id,
        IReadOnlyList<Media> Media
    );
}

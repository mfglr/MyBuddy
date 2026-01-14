using Shared.Objects;

namespace Shared.Events.MediaService
{
    public record MediaClassfiedEvent(Guid Id, ModerationResult ModerationResult);
}

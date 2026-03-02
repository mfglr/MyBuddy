using Shared.Events.SharedObjects;

namespace Shared.Events.PostService
{
    public record PostContentClassifiedEvent(Guid Id, ModerationResult ModerationResult);
}

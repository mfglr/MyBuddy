using Shared.Events.SharedObjects;

namespace Shared.Events.UserService
{
    public record UserMediaClassfiedEvent(Guid Id, string BlobName, ModerationResult ModerationResult);
}

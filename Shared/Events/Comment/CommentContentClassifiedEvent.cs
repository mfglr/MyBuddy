using Shared.Events.SharedObjects;

namespace Shared.Events.Comment
{
    public record CommentContentClassifiedEvent(Guid Id, ModerationResult ModerationResult);
}

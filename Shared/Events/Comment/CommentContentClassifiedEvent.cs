using Media.Models;

namespace Shared.Events.Comment
{
    public record CommentContentClassifiedEvent(Guid Id, ModerationResult ModerationResult);
}

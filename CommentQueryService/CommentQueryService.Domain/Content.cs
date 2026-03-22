using Media.Models;

namespace CommentQueryService.Domain
{
    public class Content(string value, ModerationResult? moderationResult)
    {
        public string Value { get; private set; } = value;
        public ModerationResult? ModerationResult { get; private set; } = moderationResult;
    }
}

using Media.Models;

namespace CommentQueryService.Domain.CommentAggregate
{
    public class CommentContent(string value, ModerationResult? moderationResult)
    {
        public string Value { get; private set; } = value;
        public ModerationResult? ModerationResult { get; private set; } = moderationResult;
    }
}

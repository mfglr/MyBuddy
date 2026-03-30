using Media.Models;

namespace PostQueryService.Domain
{
    public class Content(string value, ModerationResult? moderationResult)
    {
        public string Value { get; private set; } = value;
        public ModerationResult? ModerationResult { get; private set; } = moderationResult;
    }
}

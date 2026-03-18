using Media.Models;

namespace PostQueryService.Shared.Model
{
    public class Content
    {
        public string Value { get; private set; }
        public ModerationResult? ModerationResult { get; private set; }

        private Content(string value) => Value = value;

        public Content(string value,  ModerationResult? moderationResult)
        {
            Value = value;
            ModerationResult = moderationResult;
        }
    }
}

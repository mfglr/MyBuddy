using Media.Models;

namespace CommentQueryService.Shared.Model
{
    public class Content
    {

        public string Value { get; private set; } = null!;
        public ModerationResult? ModerationResult { get; set; }

        private Content() { }

        public Content(string value, ModerationResult? moderationResult)
        {
            Value = value;
            ModerationResult = moderationResult;
        }
    }
}

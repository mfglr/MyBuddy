using Shared.Objects;

namespace QueryService.Domain.PostDomain
{
    public class Content
    {
        public string Value { get; private set; } = null!;
        public ModerationResult ModerationResult { get; private set; } = null!;

        public Content(string value, ModerationResult moderationResult)
        {
            Value = value;
            ModerationResult = moderationResult;
        }

        private Content() { }
    }
}

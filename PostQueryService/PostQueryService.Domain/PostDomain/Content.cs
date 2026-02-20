namespace PostQueryService.Domain.PostDomain
{
    public class Content
    {
        public string Value { get; private set; } = null!;
        public ModerationResult ModerationResult { get; private set; } = null!;

        private Content(){}

        public Content(string value,  ModerationResult moderationResult)
        {
            Value = value;
            ModerationResult = moderationResult;
        }
    }
}

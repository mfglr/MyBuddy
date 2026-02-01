namespace PostQueryService.Domain.PostDomain
{
    public class Content
    {
        public string Value { get; private set; }
        public ModerationResult ModerationResult { get; private set; }

        private Content(){}

        public Content(string value,  ModerationResult moderationResult)
        {
            Value = value;
            ModerationResult = moderationResult;
        }
    }
}

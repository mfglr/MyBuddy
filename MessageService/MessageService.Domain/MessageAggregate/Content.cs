namespace MessageService.Domain.MessageAggregate
{
    public class Content
    {
        public readonly static int MaxLength = 4096;

        public string Value { get; private set; }
        public Content(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MaxLength)
                throw new InvalidContentException();
            Value = value;
        }

        public static Content Deleted() => new("[Deleted]");
    }
}

namespace MessageService.Domain
{
    public class Content
    {
        public readonly int MaxLegth = 4096;
        public string Value { get; private set; }

        public Content(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MaxLegth)
                throw new ContentLengthException();
            Value = value;
        }

    }
}

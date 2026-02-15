namespace StudyProgramService.Domain
{
    public class Description
    {
        public static readonly int MinLength = 16;
        public static readonly int MaxLength = 1024;
        public string Value { get; private set; }

        public Description(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < MinLength || value.Length > MaxLength)
                throw new InvalidDescriptionException();
            Value = value;
        }
    }
}

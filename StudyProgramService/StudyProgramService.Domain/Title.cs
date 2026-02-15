namespace StudyProgramService.Domain
{
    public class Title
    {
        public static readonly int MinLength = 3;
        public static readonly int MaxLength = 128;
        public string Value { get; private set; }

        public Title(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < MinLength || value.Length > MaxLength)
                throw new InvalidTitleException();
            Value = value;
        }
    }
}

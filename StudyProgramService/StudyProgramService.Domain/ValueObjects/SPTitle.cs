using StudyProgramService.Domain.Exceptions;

namespace StudyProgramService.Domain.ValueObjects
{
    public class SPTitle
    {
        public static readonly int MinLength = 3;
        public static readonly int MaxLength = 128;
        public string Value { get; private set; }

        public SPTitle(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < MinLength || value.Length > MaxLength)
                throw new InvalidSPTitleValueException();
            Value = value;
        }
    }
}

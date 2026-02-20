using StudyProgramService.Domain.Exceptions;

namespace StudyProgramService.Domain.ValueObjects
{
    public class SPDescription
    {
        public static readonly int MinLength = 16;
        public static readonly int MaxLength = 1024;
        public string Value { get; private set; }

        public SPDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < MinLength || value.Length > MaxLength)
                throw new InvalidSPDescriptionException();
            Value = value;
        }
    }
}

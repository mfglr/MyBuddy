using StudyProgramService.Domain.StudyProgramAggregate.Exceptions;

namespace StudyProgramService.Domain.StudyProgramAggregate.ValueObjects
{
    public class StudyProgramTitle
    {
        public static readonly int MinLength = 3;
        public static readonly int MaxLength = 128;
        public string Value { get; private set; }

        public StudyProgramTitle(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < MinLength || value.Length > MaxLength)
                throw new InvalidTitleValueException();
            Value = value;
        }
    }
}

using StudyProgramService.Domain.StudyProgramAggregate.Exceptions;

namespace StudyProgramService.Domain.StudyProgramAggregate.ValueObjects
{
    public class StudyProgramDaysPerWeek
    {
        public int Value { get; private set; }

        public StudyProgramDaysPerWeek(int value)
        {
            if (value <= 0 || value > 7)
                throw new InvalidDaysPerWeekValueException();
            Value = value;
        }
    }
}

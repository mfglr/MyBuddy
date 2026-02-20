using StudyProgramService.Domain.Exceptions;

namespace StudyProgramService.Domain.ValueObjects
{
    public class SPDaysPerWeek
    {
        public int Value { get; private set; }

        public SPDaysPerWeek(int value)
        {
            if (value <= 0 || value > 7)
                throw new InvalidSPDaysPerWeekValueException();
            Value = value;
        }
    }
}

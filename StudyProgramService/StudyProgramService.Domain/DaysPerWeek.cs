namespace StudyProgramService.Domain
{
    public class DaysPerWeek
    {
        public int Value { get; private set; }

        public DaysPerWeek(int value)
        {
            if (value <= 0 || value > 7)
                throw new InvalidDaysPerWeekValueException();
            Value = value;
        }
    }
}

namespace StudyProgramService.Domain
{
    public class DailyStudyTarget
    {
        public int Value { get; private set; }

        public DailyStudyTarget(int value)
        {
            if (value <= 0 || value > 1440)
                throw new InvalidDailyStudyTarget();
            Value = value;
        }
    }
}

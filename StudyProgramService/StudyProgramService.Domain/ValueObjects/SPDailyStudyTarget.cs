using StudyProgramService.Domain.Exceptions;

namespace StudyProgramService.Domain.ValueObjects
{
    public class SPDailyStudyTarget
    {
        public int Value { get; private set; }

        public SPDailyStudyTarget(int value)
        {
            if (value <= 0 || value > 1440)
                throw new InvalidSPDailyStudyTargetException();
            Value = value;
        }
    }
}

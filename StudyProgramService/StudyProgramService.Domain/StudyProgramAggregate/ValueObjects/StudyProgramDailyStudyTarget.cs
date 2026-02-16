using StudyProgramService.Domain.StudyProgramAggregate.Exceptions;

namespace StudyProgramService.Domain.StudyProgramAggregate.ValueObjects
{
    public class StudyProgramDailyStudyTarget
    {
        public int Value { get; private set; }

        public StudyProgramDailyStudyTarget(int value)
        {
            if (value <= 0 || value > 1440)
                throw new InvalidDailyStudyTargetException();
            Value = value;
        }
    }
}

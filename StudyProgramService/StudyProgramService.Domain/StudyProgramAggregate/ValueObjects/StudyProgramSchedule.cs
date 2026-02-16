namespace StudyProgramService.Domain.StudyProgramAggregate.ValueObjects
{
    public class StudyProgramSchedule(StudyProgramDailyStudyTarget dailyStudyTarget, StudyProgramDaysPerWeek daysPerWeek, StudyProgramDurationInWeeks durationInWeeks)
    {
        public StudyProgramDailyStudyTarget DailyStudyTarget { get; private set; } = dailyStudyTarget;
        public StudyProgramDaysPerWeek DaysPerWeek { get; private set; } = daysPerWeek;
        public StudyProgramDurationInWeeks DurationInWeeks { get; private set; } = durationInWeeks;
    }
}

namespace StudyProgramService.Domain
{
    public class Schedule(DailyStudyTarget dailyStudyTarget, DaysPerWeek daysPerWeek, DurationInWeeks durationInWeeks)
    {
        public DailyStudyTarget DailyStudyTarget { get; private set; } = dailyStudyTarget;
        public DaysPerWeek DaysPerWeek { get; private set; } = daysPerWeek;
        public DurationInWeeks DurationInWeeks { get; private set; } = durationInWeeks;
    }
}

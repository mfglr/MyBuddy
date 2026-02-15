using Shared.Events.StudyProgramService;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.UpdateSchedule
{
    internal class UpdateScheduleMapper
    {
        public StudyProgramUpdatedEvent Map(StudyProgram studyProgram) =>
            new(
                studyProgram.Id,
                studyProgram.CreatedAt,
                studyProgram.UpdatedAt,
                studyProgram.Version,
                studyProgram.IsDeleted,
                studyProgram.UserId,
                studyProgram.Title.Value,
                studyProgram.Description.Value,
                studyProgram.Schedule.DailyStudyTarget.Value,
                studyProgram.Schedule.DaysPerWeek.Value,
                studyProgram.Schedule.DurationInWeeks.Value,
                studyProgram.Status.Value
            );
    }
}

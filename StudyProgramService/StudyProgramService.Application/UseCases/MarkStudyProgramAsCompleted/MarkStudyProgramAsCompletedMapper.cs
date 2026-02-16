using Shared.Events.StudyProgramService;
using StudyProgramService.Domain.StudyProgramAggregate.Entities;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsCompleted
{
    internal class MarkStudyProgramAsCompletedMapper
    {
        public StudyProgramMarkedAsDraftEvent Map(StudyProgram studyProgram) =>
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

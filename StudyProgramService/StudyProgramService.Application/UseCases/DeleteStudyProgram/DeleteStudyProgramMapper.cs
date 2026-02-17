using Shared.Events.StudyProgramService;
using StudyProgramService.Domain.StudyProgramAggregate.Entities;

namespace StudyProgramService.Application.UseCases.DeleteStudyProgram
{
    internal class DeleteStudyProgramMapper
    {
        public StudyProgramDeletedEvent Map(StudyProgram studyProgram) =>
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
                studyProgram.Status.Value,
                studyProgram.Capacity.Value
            );
    }
}

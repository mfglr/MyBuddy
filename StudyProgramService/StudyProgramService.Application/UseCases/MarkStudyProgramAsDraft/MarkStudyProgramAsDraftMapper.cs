using Shared.Events.StudyProgramService;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsDraft
{
    internal class MarkStudyProgramAsDraftMapper
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
                studyProgram.DailyStudyTarget.Value,
                studyProgram.DaysPerWeek.Value,
                studyProgram.DurationInWeeks.Value,
                (int)studyProgram.Status,
                studyProgram.Capacity.Value
            );
    }
}

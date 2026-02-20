using Shared.Events.StudyProgramService;
using StudyProgramService.Domain.Entities;

namespace StudyProgramService.Application.UseCases.UpdateSPTitle
{
    internal class UpdateSPTitleMapper
    {
        public SPTitleUpdatedEvent Map(SP studyProgram) =>
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
                (int)studyProgram.Status
            );
    }
}

using Shared.Events.StudyProgramService;
using StudyProgramService.Domain.Entities;

namespace StudyProgramService.Application.UseCases.CreateSP
{
    internal class CreateSPMapper
    {
        public SPCreatedEvent Map(SP studyProgram, int capacity) =>
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
                capacity
            );
    }
}

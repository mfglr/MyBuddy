using MediatR;

namespace StudyProgramService.Application.UseCases.CreateStudyProgram
{
    public record CreateStudyProgramRequest(
        string Title,
        string Description,
        int DailyStudyTarget,
        int DaysPerWeek,
        int DurationInWeeks,
        decimal Money,
        string Currency,
        int Capacity
    ) : IRequest<CreateStudyProgramResponse>;
}

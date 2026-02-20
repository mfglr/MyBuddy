using MediatR;

namespace StudyProgramService.Application.UseCases.CreateSP
{
    public record CreateSPRequest(
        string Title,
        string Description,
        int DailyStudyTarget,
        int DaysPerWeek,
        int DurationInWeeks,
        decimal Money,
        string Currency,
        int Capacity,
        string EnrollmentStrategy
    ) : IRequest<CreateSPResponse>;
}

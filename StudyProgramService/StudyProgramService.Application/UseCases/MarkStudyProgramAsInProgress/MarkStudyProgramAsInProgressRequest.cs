using MediatR;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsInProgress
{
    public record MarkStudyProgramAsInProgressRequest(Guid Id) : IRequest;
}

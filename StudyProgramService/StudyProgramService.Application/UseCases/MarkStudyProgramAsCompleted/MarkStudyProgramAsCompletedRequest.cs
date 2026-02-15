using MediatR;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsCompleted
{
    public record MarkStudyProgramAsCompletedRequest(Guid Id) : IRequest;
}

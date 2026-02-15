using MediatR;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsActive
{
    public record MarkStudyProgramAsActiveRequest(Guid Id) : IRequest;
}

using MediatR;

namespace StudyProgramService.Application.UseCases.MarkSPAsInProgress
{
    public record MarkSPAsInProgressRequest(Guid Id) : IRequest;
}

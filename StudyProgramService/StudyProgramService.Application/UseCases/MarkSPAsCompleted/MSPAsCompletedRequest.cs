using MediatR;

namespace StudyProgramService.Application.UseCases.MarkSPAsCompleted
{
    public record MSPAsCompletedRequest(Guid Id) : IRequest;
}

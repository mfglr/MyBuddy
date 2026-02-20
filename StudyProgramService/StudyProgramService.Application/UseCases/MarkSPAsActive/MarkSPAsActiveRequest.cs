using MediatR;

namespace StudyProgramService.Application.UseCases.MarkSPAsActive
{
    public record MarkSPAsActiveRequest(Guid Id) : IRequest;
}

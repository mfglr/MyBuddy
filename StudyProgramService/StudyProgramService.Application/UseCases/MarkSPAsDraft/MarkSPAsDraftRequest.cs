using MediatR;

namespace StudyProgramService.Application.UseCases.MarkSPAsDraft
{
    public record MarkSPAsDraftRequest(Guid Id) : IRequest;
}

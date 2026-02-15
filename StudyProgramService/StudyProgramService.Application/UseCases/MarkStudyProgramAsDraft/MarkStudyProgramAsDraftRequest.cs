using MediatR;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsDraft
{
    public record MarkStudyProgramAsDraftRequest(Guid Id) : IRequest;
}

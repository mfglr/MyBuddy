using MediatR;

namespace StudyProgramApplicationService.Application.UseCases.CreateSPA
{
    public record CreateSPARequest(Guid StudyProgramId, Guid StudyProgramOwnerId) : IRequest;
}

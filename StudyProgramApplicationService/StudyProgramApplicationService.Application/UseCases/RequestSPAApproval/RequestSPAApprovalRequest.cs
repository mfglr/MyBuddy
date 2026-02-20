using MediatR;

namespace StudyProgramApplicationService.Application.UseCases.RequestSPAApproval
{
    public record RequestSPAApprovalRequest(Guid StudyProgramId, Guid UserId) : IRequest;
}

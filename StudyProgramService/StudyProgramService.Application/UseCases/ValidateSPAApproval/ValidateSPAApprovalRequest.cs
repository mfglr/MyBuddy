using MediatR;

namespace StudyProgramService.Application.UseCases.ValidateSPAApproval
{
    public record ValidateSPAApprovalRequest(Guid StudyProgramId, Guid UserId) : IRequest;
}

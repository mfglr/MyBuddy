using MediatR;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsApproved
{
    public record MarkSPAAsApprovedRequest(Guid StudyProgramId, Guid UserId) : IRequest;
}

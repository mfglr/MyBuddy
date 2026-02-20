using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsRejected
{
    public record MarkSPAAsRejectedRequest(Guid StudyProgramId, Guid UserId, SPARejectionReason Reason) : IRequest;
}

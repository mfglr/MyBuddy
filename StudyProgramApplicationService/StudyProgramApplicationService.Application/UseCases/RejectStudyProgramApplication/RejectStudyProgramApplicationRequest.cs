using MediatR;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.RejectStudyProgramApplication
{
    public record RejectStudyProgramApplicationRequest(Guid StudyProgramId, Guid UserId, StudyProgramApplicationRejectionReason Reason) : IRequest;
}

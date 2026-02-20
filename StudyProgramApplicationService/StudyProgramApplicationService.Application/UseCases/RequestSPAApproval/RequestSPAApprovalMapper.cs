using Shared.Events.StudyProgramService;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.RequestSPAApproval
{
    internal class RequestSPAApprovalMapper
    {
        public SPAApprovalRequestedEvent Map(SPA application) =>
            new(
                application.StudyProgramId,
                application.UserId,
                application.CreatedAt,
                application.UpdatedAt,
                application.Version,
                (int)application.Status,
                application.RejectionReason
            );
    }
}

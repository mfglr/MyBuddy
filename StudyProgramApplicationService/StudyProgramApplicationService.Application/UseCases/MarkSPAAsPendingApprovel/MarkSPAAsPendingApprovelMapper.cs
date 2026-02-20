using Shared.Events.StudyProgramService;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsPendingApprovel
{
    internal class MarkSPAAsPendingApprovelMapper
    {
        public SPAMarkedAsPendingApprovalEvent Map(SPA application) =>
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

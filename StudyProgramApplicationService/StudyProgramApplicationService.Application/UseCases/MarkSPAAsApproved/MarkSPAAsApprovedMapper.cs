using Shared.Events.StudyProgramService;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsApproved
{
    internal class MarkSPAAsApprovedMapper
    {
        public SPAApprovedEvent Map(SPA application) =>
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

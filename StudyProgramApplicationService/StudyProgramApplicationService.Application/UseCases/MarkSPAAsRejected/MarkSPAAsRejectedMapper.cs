using Shared.Events.StudyProgramService;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsRejected
{
    internal class MarkSPAAsRejectedMapper
    {
        public SPARejectedEvent Map(SPA application) =>
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

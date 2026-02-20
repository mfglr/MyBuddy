using StudyProgramApplicationService.Domain;
using Shared.Events.StudyProgramService;

namespace StudyProgramApplicationService.Application.UseCases.CreateSPA
{
    internal class CreateSPAMapper
    {
        public SPACreatedEvent Map(SPA application) =>
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

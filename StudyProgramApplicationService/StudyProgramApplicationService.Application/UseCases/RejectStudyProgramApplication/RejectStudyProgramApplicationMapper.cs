using Shared.Events.StudyProgramService.StudyProgramApplication;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.RejectStudyProgramApplication
{
    internal class RejectStudyProgramApplicationMapper
    {
        public StudyProgramApplicationRejectedEvent Map(StudyProgramApplication application) =>
            new(
                application.StudyProgramId,
                application.UserId,
                application.CreatedAt,
                application.UpdatedAt,
                application.Version,
                (int)application.Status,
                (int?)application.RejectionReason,
                application.IsValidatedByStudyProgram
            );
    }
}

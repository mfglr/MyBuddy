using StudyProgramApplicationService.Domain;
using Shared.Events.StudyProgramService.StudyProgramApplication;

namespace StudyProgramApplicationService.Application.UseCases.CreateStudyProgramApplication
{
    internal class CreateStudyProgramApplicationMapper
    {
        public StudyProgramApplicationCreatedEvent Map(StudyProgramApplication application) =>
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

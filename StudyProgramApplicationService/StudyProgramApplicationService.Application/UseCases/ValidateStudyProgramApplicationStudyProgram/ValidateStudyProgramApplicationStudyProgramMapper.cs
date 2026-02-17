using Shared.Events.StudyProgramService.StudyProgramApplication;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.ValidateStudyProgramApplicationStudyProgram
{
    internal class ValidateStudyProgramApplicationStudyProgramMapper
    {
        public StudyProgramApplicationValidatedEvent Map(StudyProgramApplication application) =>
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

namespace Shared.Events.StudyProgramService.StudyProgramApplication
{
    public record StudyProgramApplicationValidationSuccessEvent_StudyProgramService(
        Guid StudyPromamId,
        Guid UserId
    );
}

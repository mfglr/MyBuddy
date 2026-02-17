namespace Shared.Events.StudyProgramService.StudyProgramApplication
{
    public record StudyProgramApplicationValidationFailedEvent_StudyProgramService(
        Guid StudyPromamId,
        Guid UserId,
        int Reason
    );
}

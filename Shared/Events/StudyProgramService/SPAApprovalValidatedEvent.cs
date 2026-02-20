namespace Shared.Events.StudyProgramService
{
    public record SPAApprovalValidatedEvent(
        Guid StudyProgramId,
        Guid UserId
    );
}

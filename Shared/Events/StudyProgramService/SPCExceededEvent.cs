namespace Shared.Events.StudyProgramService
{
    public record SPCExceededEvent(
        Guid StudyProgramId,
        Guid UserId,
        SPARejectionReason RejectionReason
    );
}

namespace Shared.Events.StudyProgramService
{
    public record SPAApprovalInvalidatedEvent(
        Guid StudyProgramId,
        Guid UserId,
        SPARejectionReason RejectionReason
    );
}

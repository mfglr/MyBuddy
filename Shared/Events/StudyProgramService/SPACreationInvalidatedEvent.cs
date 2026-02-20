namespace Shared.Events.StudyProgramService
{
    public record SPACreationInvalidatedEvent(
        Guid StudyProgramId,
        Guid UserId,
        SPARejectionReason RejectionReason
    );
}

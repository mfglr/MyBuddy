namespace Shared.Events.StudyProgramService.StudyProgramInvite
{
    public record SPICreationInvalidatedEvent(
        Guid StudyProgramId,
        Guid UserId,
        SPIInvalidationReason Reason
    );
}

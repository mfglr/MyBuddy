namespace Shared.Events.StudyProgramService.StudyProgramInvite
{
    public record SPICreationValidatedEvent(
        Guid StudyProgramId,
        Guid UserId
    );
}

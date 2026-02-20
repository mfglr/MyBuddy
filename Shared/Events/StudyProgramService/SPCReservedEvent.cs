namespace Shared.Events.StudyProgramService
{
    public record SPCReservedEvent(
        Guid StudyProgramId,
        Guid UserId
    );
}

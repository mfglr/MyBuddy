namespace Shared.Events.StudyProgramService
{
    public record SPACreationValidatedEvent(
        Guid StudyProgramId,
        Guid UserId,
        string EnrollmentStrategy
    );
}

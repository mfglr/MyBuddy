namespace Shared.Events.StudyProgramService
{
    public record EnrollmentRequestCreatedEvent(
        Guid StudyProgramId,
        Guid UserId,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        string Status
    );
}

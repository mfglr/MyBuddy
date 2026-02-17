namespace Shared.Events.StudyProgramService
{
    public record StudyProgramEnrollmentFailedEvent(Guid EnrollmentId, string Reason);
}

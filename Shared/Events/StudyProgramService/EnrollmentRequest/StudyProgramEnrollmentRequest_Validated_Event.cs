namespace Shared.Events.StudyProgramService.EnrollmentRequest
{
    public record EnrollmentRequestValidatedEvent(
        Guid StudyProgramId,
        Guid UserId,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        string Status,
        StudyProgramEnrollmentRequest_RejectionReason? RejectionReason,
        bool IsValidatedByStudyProgram
    );
}

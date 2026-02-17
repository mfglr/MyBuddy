namespace Shared.Events.StudyProgramService.EnrollmentRequest
{
    public record StudyProgramEnrollmentRequest_Created_Event(
        Guid StudyProgramId,
        Guid UserId,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        string Status,
        StudyProgramEnrollmentRequest_RejectionReason? RejectionReason,
        bool IsStudyProgramValidated
    );
}

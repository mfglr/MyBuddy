namespace Shared.Events.StudyProgramService.EnrollmentRequest
{
    public record StudyProgramEnrollmentRequest_RejectedByStudyProgram_Event(
        Guid StudyPromamId,
        Guid UserId,
        StudyProgramEnrollmentRequest_RejectionReason Reason
    );
}

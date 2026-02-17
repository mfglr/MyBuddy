namespace Shared.Events.StudyProgramService.EnrollmentRequest
{
    public record StudyProgramEnrollmentRequest_ValidationSuccessByStudyProgram_Event(
        Guid StudyPromamId,
        Guid UserId
    );
}

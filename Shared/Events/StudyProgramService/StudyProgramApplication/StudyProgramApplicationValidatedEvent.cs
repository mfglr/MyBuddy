namespace Shared.Events.StudyProgramService.StudyProgramApplication
{
    public record StudyProgramApplicationValidatedEvent(
        Guid StudyProgramId,
        Guid UserId,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        int Status,
        int? RejectionReason,
        bool IsValidatedByStudyProgram
    );
}

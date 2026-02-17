namespace Shared.Events.StudyProgramService.StudyProgramApplication
{
    public record StudyProgramApplicationRejectedEvent(
        Guid StudyProgramId,
        Guid UserId,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        int Status,
        int? RejectionReason,
        bool IsStudyProgramValidated
    );
}

namespace Shared.Events.StudyProgramService
{
    public record SPAApprovedEvent(
        Guid StudyProgramId,
        Guid UserId,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        int Status,
        SPARejectionReason? RejectionReason
    );
}

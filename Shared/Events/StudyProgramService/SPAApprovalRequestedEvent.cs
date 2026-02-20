namespace Shared.Events.StudyProgramService
{
    public record SPAApprovalRequestedEvent(
        Guid StudyProgramId,
        Guid UserId,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        int Status,
        SPARejectionReason? RejectionReason
    );
}

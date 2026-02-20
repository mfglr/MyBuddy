namespace Shared.Events.StudyProgramService
{
    public record SPAMarkedAsAwaitingCapacityReservationEvent(
        Guid StudyProgramId,
        Guid UserId,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        int Status,
        SPARejectionReason? RejectionReason
    );
}

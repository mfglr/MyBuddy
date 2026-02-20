using Shared.Events.StudyProgramService;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsAwaitingCapacityReservation
{
    internal class MarkSPAAsAwaitingCapacityReservationMapper
    {
        public SPAMarkedAsAwaitingCapacityReservationEvent Map(SPA spa) =>
            new(
                spa.StudyProgramId,
                spa.UserId,
                spa.CreatedAt,
                spa.UpdatedAt,
                spa.Version,
                (int)spa.Status,
                spa.RejectionReason
            );
    }
}

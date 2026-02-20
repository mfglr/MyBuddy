using Shared.Events.StudyProgramService;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsAwaitingCapacityReservation;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsAwaitingCapacityReservation_OnSPAApprovalValidated
{
    internal class Mapper
    {
        public MarkSPAAsAwaitingCapacityReservationRequest Map(SPAApprovalValidatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }
}

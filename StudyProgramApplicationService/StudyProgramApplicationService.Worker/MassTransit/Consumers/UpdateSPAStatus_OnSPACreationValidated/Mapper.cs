using Shared.Events.StudyProgramService;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsAwaitingCapacityReservation;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsPendingApprovel;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.UpdateSPAStatus_OnSPACreationValidated
{
    internal class Mapper
    {
        public MarkSPAAsPendingApprovelRequest MapApprovalRequest(SPACreationValidatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );

        public MarkSPAAsAwaitingCapacityReservationRequest MapReservationRequest(SPACreationValidatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }
}

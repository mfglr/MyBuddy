using Shared.Events.StudyProgramService;
using StudyProgramCapacityService.Application.UseCases.ReserveSPC;

namespace StudyProgramCapacityService.Worker.MassTransit.Consumers.ReserveSPC_OnSPAApprovalValidated
{
    internal class Mapper
    {
        public ReserveSPCRequest Map(SPAApprovalValidatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }
}

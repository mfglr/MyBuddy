using Shared.Events.StudyProgramService;
using StudyProgramCapacityService.Application.UseCases.ReserveSPC;

namespace StudyProgramCapacityService.Worker.MassTransit.Consumers.ReserveSPC_OnSPACreationValidated
{
    internal class Mapper
    {
        public ReserveSPCRequest Map(SPACreationValidatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }
}

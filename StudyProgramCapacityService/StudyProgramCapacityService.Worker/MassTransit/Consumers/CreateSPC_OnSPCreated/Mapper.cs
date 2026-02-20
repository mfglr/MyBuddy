using Shared.Events.StudyProgramService;
using StudyProgramCapacityService.Application.UseCases.CreateCapacity;

namespace StudyProgramCapacityService.Worker.MassTransit.Consumers.CreateSPC_OnSPCreated
{
    internal class Mapper
    {
        public CreateSPCRequest Map(SPCreatedEvent @event) =>
            new(
                @event.Id,
                @event.UserId,
                @event.Capacity
            );
    }
}

using MassTransit;
using MediatR;
using StudyProgramCapacityService.Domain;

namespace StudyProgramCapacityService.Application.UseCases.ReserveSPC
{
    internal class ReserveSPCHandler(ReserveSPCMapper mapper, IPublishEndpoint publishEndpoint, ISPCManager capacityManager) : IRequestHandler<ReserveSPCRequest>
    {
        public async Task Handle(ReserveSPCRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await capacityManager.Reserve(request.StudyProgramId);
                var @event = mapper.MapReservedEvent(request);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            catch (InsufficientCapacityException)
            {
                var @event = mapper.MapExceededEvent(request);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
        }
    }
}

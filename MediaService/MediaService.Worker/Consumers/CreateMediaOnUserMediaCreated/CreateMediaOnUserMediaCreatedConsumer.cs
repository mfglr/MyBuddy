using MassTransit;
using MediatR;
using Shared.Events.UserService;

namespace MediaService.Worker.Consumers.CreateMediaOnUserMediaCreated
{
    internal class CreateMediaOnUserMediaCreatedConsumer(
        ISender sender,
        CreateMediaOnUserMediaCreatedMapper mapper
    ) : IConsumer<UserMediaCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserMediaCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

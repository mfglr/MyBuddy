using MassTransit;
using MediatR;
using Shared.Events.UserService;

namespace MediaService.Worker.Consumers.CreateMediaOnUserMediaCreated
{
    internal class CreateMedia_OnUserMediaCreated_MediaService(
        ISender sender,
        CreateMedia_OnUserMediaCreated_Mapper mapper
    ) : IConsumer<UserMediaCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserMediaCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

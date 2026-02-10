using MassTransit;
using MediatR;
using Shared.Events.MessageService;

namespace MessageService.Api.Consumers.SendMessage_OnMessageCreated
{
    internal class SendMessage_OnMessageCreated_MessageService(ISender sender, Mapper mapper) : IConsumer<MessageCreatedEvent>
    {
        public Task Consume(ConsumeContext<MessageCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

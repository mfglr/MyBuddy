using MassTransit;
using MediatR;
using Shared.Events.MessageService;

namespace MessageService.Api.Consumers.SendMessage_OnMessagesMarkedAsReceived
{
    internal class SendMessage_OnMessagesMarkedAsReceived_MessageService(Mapper mapper, ISender sender) : IConsumer<MessagesMarkedAsDeliveredEvent>
    {
        public Task Consume(ConsumeContext<MessagesMarkedAsDeliveredEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

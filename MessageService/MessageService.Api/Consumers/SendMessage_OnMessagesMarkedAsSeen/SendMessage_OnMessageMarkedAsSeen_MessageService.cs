using MassTransit;
using MediatR;
using Shared.Events.MessageService;

namespace MessageService.Api.Consumers.SendMessage_OnMessagesMarkedAsSeen
{
    internal class SendMessage_OnMessageMarkedAsSeen_MessageService(Mapper mapper, ISender sender) : IConsumer<MessagesMarkedAsSeenEvent>
    {
        public Task Consume(ConsumeContext<MessagesMarkedAsSeenEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

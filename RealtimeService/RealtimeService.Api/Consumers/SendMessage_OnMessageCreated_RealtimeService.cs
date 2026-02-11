using AutoMapper;
using MassTransit;
using MediatR;
using RealtimeService.Application.UseCases.SendMessage;
using Shared.Events.MessageService;

namespace RealtimeService.Api.Consumers
{
    public class SendMessage_OnMessageCreated_RealtimeService(ISender sender, IMapper mapper) : IConsumer<MessageCreatedEvent>
    {
        public Task Consume(ConsumeContext<MessageCreatedEvent> context) =>
            sender.Send(mapper.Map<MessageCreatedEvent, SendMessageRequest>(context.Message), context.CancellationToken);
    }
}

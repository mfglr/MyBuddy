using MessageService.Aplication.UseCases.SendMessage;
using Shared.Events.MessageService;

namespace MessageService.Api.Consumers.SendMessage_OnMessageCreated
{
    internal class Mapper
    {
        public SendMessageRequest Map(MessageCreatedEvent messageCreatedEvent) =>
            new(
                messageCreatedEvent.ReceiverId,
                [
                    new(
                        messageCreatedEvent.Id,
                        messageCreatedEvent.CreatedAt,
                        messageCreatedEvent.UpdatedAt,
                        messageCreatedEvent.Version,
                        messageCreatedEvent.SenderId,
                        messageCreatedEvent.ReceiverId,
                        messageCreatedEvent.Content,
                        messageCreatedEvent.ReceivedAt,
                        messageCreatedEvent.SeenAt
                    )
                ]
            );
    }
}

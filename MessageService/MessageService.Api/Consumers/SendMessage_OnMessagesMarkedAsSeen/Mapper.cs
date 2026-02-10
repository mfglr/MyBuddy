using MessageService.Aplication.UseCases.SendMessage;
using Shared.Events.MessageService;

namespace MessageService.Api.Consumers.SendMessage_OnMessagesMarkedAsSeen
{
    internal class Mapper
    {
        public SendMessageRequest Map(MessagesMarkedAsSeenEvent @event) =>
            new(
                @event.UserId,
                @event.Messages.Select(
                    x => new SendMessageRequest_Message(
                        x.Id,
                        x.CreatedAt,
                        x.UpdatedAt,
                        x.Version,
                        x.SenderId,
                        x.ReceiverId,
                        x.Content,
                        x.ReceivedAt,
                        x.SeenAt
                    )
                )
            );
    }
}

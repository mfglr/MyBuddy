using AutoMapper;
using MassTransit;
using MediatR;
using MessageService.Domain;
using Shared.Events.MessageService;

namespace MessageService.Application.UseCases.CreateMessage
{
    internal class CreateMessageHandler(IMapper mapper,IIdentityService identityService, IMessageRepository messageRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<CreateMessageRequest>
    {
        public async Task Handle(CreateMessageRequest request, CancellationToken cancellationToken)
        {
            var senderId = identityService.UserId;
            var messages = request.Messages.Select(x => new Message(new(x.Content), senderId, x.ReceiverId));
            await messageRepository.CreateAsync(messages, cancellationToken);

            var @event = new MessageCreatedEvent(mapper.Map<IEnumerable<Message>, IEnumerable<MessageCreatedEvent_Message>>(messages));
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}

using AutoMapper;
using MassTransit;
using MediatR;
using MessageService.Domain.MessageAggregate;
using Shared.Events.MessageService;

namespace MessageService.Aplication.UseCases.CreateMessage
{
    internal class CreateMessageHandler(IMapper mapper, IMessageRepository messageRepository, IPublishEndpoint publishEndpoint, IIdentityService identityService) : IRequestHandler<CreateMessageRequest, CreateMessageResponse>
    {
        public async Task<CreateMessageResponse> Handle(CreateMessageRequest request, CancellationToken cancellationToken)
        {
            var senderId = identityService.UserId;
            var content = new Content(request.Content);
            var message = new Message(senderId, request.ReceiverId, content);
            await messageRepository.CreateAsync(message, cancellationToken);

            var @event = mapper.Map<Message,MessageCreatedEvent>(message);
            await publishEndpoint.Publish(@event, cancellationToken);
            
            return new(message.Id);
        }
    }
}

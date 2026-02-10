using AutoMapper;
using MediatR;
using MessageService.Domain.ConnectionAggregate;

namespace MessageService.Aplication.UseCases.SendMessage
{
    internal class SendMessageHandler(IConnectionRepository connectionRepository, IMapper mapper, IMessageRouter messageRouter) : IRequestHandler<SendMessageRequest>
    {
        public async Task Handle(SendMessageRequest request, CancellationToken cancellationToken)
        {
            var connection = await connectionRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (connection == null) return;

            var messages = mapper.Map<IEnumerable<SendMessageRequest_Message>, IEnumerable<MessageResponse>>(request.Messages);
            await messageRouter.SendMessageAsync(messages, connection, cancellationToken);
        }
    }
}

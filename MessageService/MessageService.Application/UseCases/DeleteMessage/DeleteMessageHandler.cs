using MediatR;
using MessageService.Domain;

namespace MessageService.Application.UseCases.DeleteMessage
{
    internal class DeleteMessageHandler(IMessageRepository messageRepository,IIdentityService identityService) : IRequestHandler<DeleteMessageRequest>
    {
        public async Task Handle(DeleteMessageRequest request, CancellationToken cancellationToken)
        {
            var receiverId = identityService.UserId;
            var messages = await messageRepository.GetByIdsAsync(request.Ids, cancellationToken);
            foreach (var message in messages)
                if (message.ReceiverId != receiverId)
                    throw new CustomUnauthorizedAccessException();
            await messageRepository.DeleteAsync(messages, cancellationToken);
        }
    }
}

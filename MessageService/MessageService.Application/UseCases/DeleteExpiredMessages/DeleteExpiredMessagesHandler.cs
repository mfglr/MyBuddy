using MediatR;
using MessageService.Domain;

namespace MessageService.Application.UseCases.DeleteExpiredMessages
{
    internal class DeleteExpiredMessagesHandler(IMessageRepository messageRepository) : IRequestHandler<DeleteExpiredMessagesRequest>
    {
        public async Task Handle(DeleteExpiredMessagesRequest request, CancellationToken cancellationToken)
        {
            var messages = await messageRepository.GetExpiredMessagesAsync(TimeSpan.FromSeconds(request.Seconds), cancellationToken);
            await messageRepository.DeleteAsync(messages, cancellationToken);
        }
    }
}

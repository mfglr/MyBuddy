using MediatR;
using RealtimeService.Domain;

namespace RealtimeService.Application.UseCases.SendMessage
{
    internal class SendMessageHandler(IMessageRouter messageRouter, IConnectionRepository connectionRepository) : IRequestHandler<SendMessageRequest>
    {
        public async Task Handle(SendMessageRequest request, CancellationToken cancellationToken)
        {
            var groups = request.Messages.GroupBy(x => x.ReceiverId);
            var tasks = new List<Task>();
            foreach(var group in groups)
                tasks.Add(SendMessageAsync(group.Key,group,cancellationToken));
            await Task.WhenAll(tasks);
        }

        private async Task SendMessageAsync(Guid receiverId, IEnumerable<SendMessageRequest_Message> messages, CancellationToken cancellationToken)
        {
            var connection = await connectionRepository.GetByIdAsync(receiverId, cancellationToken);
            if (connection == null) return;
            await messageRouter.SendAsync(messages.Select(x => x.Content), connection, cancellationToken);
        }
    }
}

using MassTransit;
using MediatR;
using MessageService.Domain.MessageAggregate;
using Shared.Events.MessageService;

namespace MessageService.Aplication.UseCases.DeleteMessages
{
    internal class DeleteMessagesHandler(IMessageRepository messsageRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<DeleteMessagesRequest>
    {
        public async Task Handle(DeleteMessagesRequest request, CancellationToken cancellationToken)
        {
            var messages = await messsageRepository.GetByIdsAsync(request.Ids, cancellationToken);
            if (messages.Count == 0) return;
            await messsageRepository.DeleteAsync(messages, cancellationToken);
            var ids = messages.Select(x => x.Id);
            await publishEndpoint.Publish(new MessagesDeletedEvent(ids),cancellationToken);
        }
    }
}

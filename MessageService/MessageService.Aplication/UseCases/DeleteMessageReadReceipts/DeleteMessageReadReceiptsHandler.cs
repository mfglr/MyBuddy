using MediatR;
using MessageService.Domain.MessageReadReceiptAggregate;

namespace MessageService.Aplication.UseCases.DeleteMessageReadReceipts
{
    internal class DeleteMessageReadReceiptsHandler(IMessageReadReceiptRepository messageReadReceiptRepository) : IRequestHandler<DeleteMessageReadReceiptsRequest>
    {
        public async Task Handle(DeleteMessageReadReceiptsRequest request, CancellationToken cancellationToken)
        {
            var messageReadReceipts = await messageReadReceiptRepository.GetByMessageIds(request.MessageIds, cancellationToken);
            await messageReadReceiptRepository.DeleteAsync(messageReadReceipts, cancellationToken);
        }
    }
}

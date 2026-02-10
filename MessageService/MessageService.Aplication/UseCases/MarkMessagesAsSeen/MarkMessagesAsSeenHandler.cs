using AutoMapper;
using MassTransit;
using MediatR;
using MessageService.Aplication.Exceptions;
using MessageService.Domain.MessageAggregate;
using MessageService.Domain.MessageReadReceiptAggregate;
using Shared.Events.MessageService;

namespace MessageService.Aplication.UseCases.MarkMessagesAsSeen
{
    internal class MarkMessagesAsSeenHandler(IUnitOfWork unitOfWork, IMessageReadReceiptRepository messageReadReceiptRepository, IIdentityService identityService, IMessageRepository messageRepository, IPublishEndpoint publishEndpoint, IMapper mapper) : IRequestHandler<MarkMessagesAsSeenRequest>
    {
        public async Task Handle(MarkMessagesAsSeenRequest request, CancellationToken cancellationToken)
        {
            var receiverId = identityService.UserId;
            var messages = await messageRepository.GetByIdsAsync(request.Ids, cancellationToken);

            if (messages.Any(x => x.ReceiverId != receiverId))
                throw new CustomUnauthorizedAccessException();

            var messageReadReceipts = messages.Select(x => new MessageReadReceipt(x.Id, receiverId));
            await messageReadReceiptRepository.CreateAsync(messageReadReceipts, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            var events =
                messages
                    .GroupBy(x => x.SenderId)
                    .Select(
                        group => new MessagesMarkedAsSeenEvent(
                            group.Key,
                            mapper.Map<IEnumerable<Message>, IEnumerable<MessagesMarkedAsSeenEvent_Message>>(group)
                        )
                    );
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}

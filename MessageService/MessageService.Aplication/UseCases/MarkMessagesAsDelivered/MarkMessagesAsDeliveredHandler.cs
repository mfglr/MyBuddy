using AutoMapper;
using MassTransit;
using MediatR;
using MessageService.Aplication.Exceptions;
using MessageService.Domain.MessageAggregate;
using MessageService.Domain.MessageDeliveryAggregate;
using Shared.Events.MessageService;

namespace MessageService.Aplication.UseCases.MarkMessagesAsDelivered
{
    internal class MarkMessagesAsDeliveredHandler(IMessageDeliveryRepository messageDeliveryRepository, IIdentityService identityService, IMessageRepository messageRepository, IPublishEndpoint publishEndpoint, IMapper mapper) : IRequestHandler<MarkMessagesAsDeliveredRequest>
    {
        public async Task Handle(MarkMessagesAsDeliveredRequest request, CancellationToken cancellationToken)
        {
            var receiverId = identityService.UserId;
            var messages = await messageRepository.GetByIdsAsync(request.Ids, cancellationToken);

            if (messages.Any(x => x.ReceiverId != receiverId))
                throw new CustomUnauthorizedAccessException();

            var prevDeleveries = await messageDeliveryRepository.GetByMessageIdsAsync(messages.Select(x => x.Id), cancellationToken);
            var messageDeliveries = messages.Where(prevDeleveries).Select(x => new MessageDelivery(x.Id, x.ReceiverId));
            await messageDeliveryRepository.CreateAsync(messageDeliveries, cancellationToken);

            var events =
                messages
                    .GroupBy(x => x.SenderId)
                    .Select(
                        group => new MessagesMarkedAsDeliveredEvent(
                            group.Key,
                            mapper.Map<IEnumerable<Message>, IEnumerable<MessagesMarkedAsDeliveredEvent_MessageDelivery>>(group)
                        )
                    );
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}

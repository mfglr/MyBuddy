using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpdatePostUser_OnAccountNameUpdated
{
    internal class UpdatePostUser_OnAccountNameUpdated_PostQueryService(
        ISender sender,
        UpdatePostUser_OnAccountNameUpdated_Mapper mapper
    ) : IConsumer<AccountNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountNameUpdatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

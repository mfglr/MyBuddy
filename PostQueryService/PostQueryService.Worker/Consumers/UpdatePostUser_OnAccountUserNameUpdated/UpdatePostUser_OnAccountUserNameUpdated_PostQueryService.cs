using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpdatePostUser_OnAccountUserNameUpdated
{
    internal class UpdatePostUser_OnAccountUserNameUpdated_PostQueryService(
        ISender sender,
        UpdatePostUser_OnAccountUserNameUpdated_Mapper mapper
    ) : IConsumer<AccountUserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountUserNameUpdatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

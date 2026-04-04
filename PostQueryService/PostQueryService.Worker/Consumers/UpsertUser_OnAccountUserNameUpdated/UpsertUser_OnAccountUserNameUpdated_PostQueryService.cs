using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUser_OnAccountUserNameUpdated
{
    internal class UpsertUser_OnAccountUserNameUpdated_PostQueryService(
        UpsertUser_OnAccountUserNameUpdated_Mapper mapper,
        ISender sender
    ) : IConsumer<AccountUserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountUserNameUpdatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

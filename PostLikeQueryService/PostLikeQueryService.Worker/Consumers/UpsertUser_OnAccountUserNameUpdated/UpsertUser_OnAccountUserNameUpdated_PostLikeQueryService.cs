using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountUserNameUpdated
{
    internal class UpsertUser_OnAccountUserNameUpdated_PostLikeQueryService(
        ISender sender,
        UpsertUser_OnAccountUserNameUpdated_Mapper mapper
    ) : IConsumer<AccountUserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountUserNameUpdatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

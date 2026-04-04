using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUser_OnAccountDeleted
{
    internal class UpsertUser_OnAccountDeleted_PostQueryService(
        ISender sender,
        UpsertUser_OnAccountDeleted_Mapper mapper
    ) : IConsumer<AccountDeletedEvent>
    {
        public Task Consume(ConsumeContext<AccountDeletedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

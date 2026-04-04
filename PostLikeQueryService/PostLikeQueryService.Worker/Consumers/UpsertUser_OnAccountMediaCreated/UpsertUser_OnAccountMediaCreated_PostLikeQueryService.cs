using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountMediaCreated
{
    internal class UpsertUser_OnAccountMediaCreated_PostLikeQueryService(
        ISender sender,
        UpsertUser_OnAccountMediaCreated_Mapper mapper
    ) : IConsumer<AccountMediaCreatedEvent>
    {
        public Task Consume(ConsumeContext<AccountMediaCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

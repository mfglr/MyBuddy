using MassTransit;
using MediatR;
using Shared.Events.Account;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountCreated
{
    internal class UpsertUser_OnAccountCreated_PostLikeQueryService(
        ISender sender,
        UpsertUser_OnAccountCreated_Mapper mapper
    ) : IConsumer<AccountCreatedEvent>
    {
        public Task Consume(ConsumeContext<AccountCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

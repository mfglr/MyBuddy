using MassTransit;
using PostLikeQueryService.Shared.Model;
using Shared.Events.Account;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountCreated
{
    internal class UpsertUser_OnAccountCreated_PostLikeQueryService(
        IUserRepository repository,
        UpsertUser_OnAccountCreated_Mapper mapper
    ) : IConsumer<AccountCreatedEvent>
    {
        public Task Consume(ConsumeContext<AccountCreatedEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

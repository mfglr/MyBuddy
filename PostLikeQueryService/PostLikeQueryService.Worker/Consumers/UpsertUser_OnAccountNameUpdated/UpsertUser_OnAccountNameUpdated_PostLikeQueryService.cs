using MassTransit;
using PostLikeQueryService.Shared.Model;
using Shared.Events.Account;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountNameUpdated
{
    internal class UpsertUser_OnAccountNameUpdated_PostLikeQueryService(
        IUserRepository repository,
        UpsertUser_OnAccountNameUpdated_Mapper mapper
    ) : IConsumer<AccountNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountNameUpdatedEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

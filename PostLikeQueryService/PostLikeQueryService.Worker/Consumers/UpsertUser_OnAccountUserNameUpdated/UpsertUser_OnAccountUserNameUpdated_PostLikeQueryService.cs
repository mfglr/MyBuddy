using MassTransit;
using PostLikeQueryService.Shared.Model;
using Shared.Events.Account;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountUserNameUpdated
{
    internal class UpsertUser_OnAccountUserNameUpdated_PostLikeQueryService(
        IUserRepository repository,
        UpsertUser_OnAccountUserNameUpdated_Mapper mapper
    ) : IConsumer<AccountUserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountUserNameUpdatedEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

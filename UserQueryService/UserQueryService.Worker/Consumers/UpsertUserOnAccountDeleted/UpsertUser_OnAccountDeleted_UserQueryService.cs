using MassTransit;
using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountDeleted
{
    internal class UpsertUser_OnAccountDeleted_UserQueryService(
        IUserRepository repository,
        UpsertUser_OnAccountDeleted_Mapper mapper
    ) : IConsumer<AccountDeletedEvent>
    {
        public Task Consume(ConsumeContext<AccountDeletedEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

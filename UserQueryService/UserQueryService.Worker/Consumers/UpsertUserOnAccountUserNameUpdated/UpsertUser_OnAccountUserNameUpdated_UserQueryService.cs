using MassTransit;
using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountUserNameUpdated
{
    internal class UpsertUser_OnAccountUserNameUpdated_UserQueryService(
        IUserRepository userRepository,
        UpsertUser_OnAccountUserNameUpdated_Mapper mapper
    ) : IConsumer<AccountUserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountUserNameUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

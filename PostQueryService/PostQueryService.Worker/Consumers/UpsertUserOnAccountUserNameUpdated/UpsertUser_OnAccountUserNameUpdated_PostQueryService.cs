using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUserOnAccountUserNameUpdated
{
    internal class UpsertUser_OnAccountUserNameUpdated_PostQueryService(
        UpsertUserOn_AccountUserNameUpdated_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<AccountUserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountUserNameUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

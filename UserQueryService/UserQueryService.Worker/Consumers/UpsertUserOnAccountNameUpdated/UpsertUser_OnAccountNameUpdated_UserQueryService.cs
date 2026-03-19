using MassTransit;
using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountNameUpdated
{
   
    internal class UpsertUser_OnAccountNameUpdated_UserQueryService(
        IUserRepository userRepository,
        UpsertUser_OnAccountNameUpdated_Mapper mapper
    ) : IConsumer<AccountNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountNameUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

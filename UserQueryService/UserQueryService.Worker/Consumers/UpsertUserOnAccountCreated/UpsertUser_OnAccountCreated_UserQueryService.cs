using MassTransit;
using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountCreated
{
    internal class UpsertUser_OnAccountCreated_UserQueryService(
        IUserRepository userRepository,
        UpsertUser_OnAccountCreated_Mapper mapper
    ) : IConsumer<AccountCreatedEvent>
    {
        public Task Consume(ConsumeContext<AccountCreatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

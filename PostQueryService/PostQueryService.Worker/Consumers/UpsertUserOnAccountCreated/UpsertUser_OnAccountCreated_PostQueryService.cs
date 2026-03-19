using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUserOnAccountCreated
{
    internal class UpsertUser_OnAccountCreated_PostQueryService(
        UpsertUser_OnAccountCreated_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<AccountCreatedEvent>
    {
        public Task Consume(ConsumeContext<AccountCreatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

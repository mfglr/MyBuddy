using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUserOnAccountNameUpdated
{
    internal class UpsertUser_OnAccountNameUpdated_PostQueryService(
        UpsertUser_OnAccountNameUpdated_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<AccountNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountNameUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

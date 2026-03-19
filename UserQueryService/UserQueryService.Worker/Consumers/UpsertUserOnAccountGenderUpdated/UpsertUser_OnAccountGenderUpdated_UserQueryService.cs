using MassTransit;
using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountGenderUpdated
{
    internal class UpsertUser_OnAccountGenderUpdated_UserQueryService(
        IUserRepository userRepository,
        UpsertUser_OnAccountGenderUpdated_Mapper mapper
    ) : IConsumer<AccountGenderUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountGenderUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

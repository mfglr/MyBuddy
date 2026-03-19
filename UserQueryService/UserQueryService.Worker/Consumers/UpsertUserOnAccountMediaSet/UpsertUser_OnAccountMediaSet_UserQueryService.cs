using MassTransit;
using Shared.Events.Account;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnAccountMediaSet
{
    internal class UpsertUser_OnAccountMediaSet_UserQueryService(
        IUserRepository userRepository,
        UpsertUser_OnAccountMediaSet_Mapper mapper
    ) : IConsumer<AccountMediaSetEvent>
    {
        public Task Consume(ConsumeContext<AccountMediaSetEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

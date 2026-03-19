using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.Account;

namespace PostQueryService.Worker.Consumers.UpsertUserOnAccountMediaSet
{
    internal class UpsertUser_OnAccountMediaSet_PostQueryService(
        UpsertUser_OnAccountMediaSet_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<AccountMediaSetEvent>
    {
        public Task Consume(ConsumeContext<AccountMediaSetEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

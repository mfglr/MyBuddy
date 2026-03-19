using CommentQueryService.Shared.Model;
using MassTransit;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnAccountUserNameUpdated
{
    internal class UpsertUser_OnAccountUserNameUpdated_CommentQueryService(
        UpsertUser_OnAccountUserNameUpdated_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<AccountUserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountUserNameUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

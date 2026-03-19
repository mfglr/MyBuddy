using CommentQueryService.Shared.Model;
using MassTransit;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountNameUpdated
{
    internal class UpsertUser_OnAccountNameUpdated_CommentQueryService(
        UpsertUser_OnAccountNameUpdated_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<AccountNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<AccountNameUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

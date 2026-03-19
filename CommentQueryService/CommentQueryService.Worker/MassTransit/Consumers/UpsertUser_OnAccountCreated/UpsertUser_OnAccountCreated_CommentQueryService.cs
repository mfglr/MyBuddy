using CommentQueryService.Shared.Model;
using CommentQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountCreated;
using MassTransit;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnUserCreated
{
    internal class UpsertUser_OnAccountCreated_CommentQueryService(
        UpsertUser_OnAccountCreated_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<AccountCreatedEvent>
    {
        public Task Consume(ConsumeContext<AccountCreatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

using CommentQueryService.Shared.Model;
using MassTransit;
using Shared.Events.Account;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountMediaSet
{
    internal class UpsertUser_OnAccountMediaSet_CommentQueryService(
        UpsertUser_OnAccountMediaSet_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<AccountMediaSetEvent>
    {
        public Task Consume(ConsumeContext<AccountMediaSetEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

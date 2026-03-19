using MassTransit;
using PostLikeQueryService.Shared.Model;
using Shared.Events.Account;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountMediaSet
{
    internal class UpsertUser_OnAccountMediaSet__PostLikeQueryService(
        IUserRepository repository,
        UpsertUser_OnAccountMediaSet_Mapper mapper) : IConsumer<AccountMediaSetEvent>
    {
        public Task Consume(ConsumeContext<AccountMediaSetEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

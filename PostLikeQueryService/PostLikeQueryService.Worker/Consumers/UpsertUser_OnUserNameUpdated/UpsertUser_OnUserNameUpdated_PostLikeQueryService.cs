using MassTransit;
using PostLikeQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnUserNameUpdated
{
    internal class UpsertUser_OnUserNameUpdated_PostLikeQueryService(
        IUserRepository repository,
        UpsertUser_OnUserNameUpdated_Mapper mapper
    ) : IConsumer<UserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<UserNameUpdatedEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

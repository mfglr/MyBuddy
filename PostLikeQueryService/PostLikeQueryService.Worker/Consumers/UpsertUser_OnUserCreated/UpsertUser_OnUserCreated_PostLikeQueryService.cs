using MassTransit;
using PostLikeQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnUserCreated
{
    internal class UpsertUser_OnUserCreated_PostLikeQueryService(
        IUserRepository repository,
        UpsertUser_OnUserCreated_Mapper mapper
    ) : IConsumer<UserCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserCreatedEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

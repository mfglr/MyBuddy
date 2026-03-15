using MassTransit;
using PostLikeQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnNameUpdated
{
    internal class UpsertUser_OnNameUpdated_PostLikeQueryService(
        IUserRepository repository,
        UpsertUser_OnNameUpdated_Mapper mapper
    ) : IConsumer<NameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<NameUpdatedEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

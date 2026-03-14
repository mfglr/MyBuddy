using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostQueryService.Worker.Consumers.UpsertUserOnNameUpdated
{
    internal class UpsertUser_OnNameUpdated_PostQueryService(
        UpsertUser_OnNameUpdated_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<NameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<NameUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

using MassTransit;
using Shared.Events.UserService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnGenderUpdated
{
    internal class UpsertUserOnGenderUpdatedConsumer(
        IUserRepository userRepository,
        UpsertUserOnGenderUpdatedMapper mapper
    ) : IConsumer<UserGenderUpdatedEvent>
    {
        public Task Consume(ConsumeContext<UserGenderUpdatedEvent> context) =>
            context.Message.IsValidVersion
                ? userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken)
                : Task.CompletedTask;
    }
}

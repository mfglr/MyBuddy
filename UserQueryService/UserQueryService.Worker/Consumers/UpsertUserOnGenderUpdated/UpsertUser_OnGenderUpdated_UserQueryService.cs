using MassTransit;
using Shared.Events.UserService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnGenderUpdated
{
    internal class UpsertUser_OnGenderUpdated_UserQueryService(
        IUserRepository userRepository,
        UpsertUser_OnGenderUpdated_Mapper mapper
    ) : IConsumer<UserGenderUpdatedEvent>
    {
        public Task Consume(ConsumeContext<UserGenderUpdatedEvent> context) =>
            context.Message.IsValidVersion
                ? userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken)
                : Task.CompletedTask;
    }
}

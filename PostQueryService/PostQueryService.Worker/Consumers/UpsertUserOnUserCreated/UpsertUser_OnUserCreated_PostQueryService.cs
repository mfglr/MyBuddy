using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostQueryService.Worker.Consumers.UpsertUserOnUserCreated
{
    internal class UpsertUser_OnUserCreated_PostQueryService(UpsertUser_OnUserCreated_Mapper mapper, IUserRepository userRepository) : IConsumer<UserCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            if (!context.Message.IsValidVersion) return Task.CompletedTask;
            var user = mapper.Map(context.Message);
            return userRepository.UpsertAsync(user, context.CancellationToken);
        }
    }
}

using MassTransit;
using Shared.Events.UserService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.UpsertUserOnUserNameUpdated
{
    internal class UpsertUser_OnUserNameUpdated_UserQueryService(
        IUserRepository userRepository,
        UpsertUser_OnUserNameUpdated_Mapper mapper
    ) : IConsumer<UserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<UserNameUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

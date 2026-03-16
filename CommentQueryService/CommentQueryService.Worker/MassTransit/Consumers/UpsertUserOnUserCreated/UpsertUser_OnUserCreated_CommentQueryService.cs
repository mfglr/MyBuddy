using CommentQueryService.Shared.Model;
using MassTransit;
using Shared.Events.UserService;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnUserCreated
{
    internal class UpsertUser_OnUserCreated_CommentQueryService(
        UpsertUser_OnUserCreated_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<UserCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserCreatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

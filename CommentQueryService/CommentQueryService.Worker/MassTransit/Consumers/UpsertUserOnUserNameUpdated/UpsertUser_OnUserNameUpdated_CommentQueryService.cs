using CommentQueryService.Shared.Model;
using MassTransit;
using Shared.Events.UserService;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnUserNameUpdated
{
    internal class UpsertUser_OnUserNameUpdated_CommentQueryService(
        UpsertUserOn_UserNameUpdated_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<UserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<UserNameUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

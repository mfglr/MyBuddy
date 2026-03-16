using CommentQueryService.Shared.Model;
using MassTransit;
using Shared.Events.UserService;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnNameUpdated
{
    internal class UpsertUser_OnNameUpdated_CommentQueryService(
        UpsertUser_OnNameUpdated_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<NameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<NameUpdatedEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

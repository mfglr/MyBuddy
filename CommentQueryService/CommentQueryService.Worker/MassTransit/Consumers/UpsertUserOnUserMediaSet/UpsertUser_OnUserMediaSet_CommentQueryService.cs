using CommentQueryService.Shared.Model;
using MassTransit;
using Shared.Events.UserService;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnUserMediaSet
{
    internal class UpsertUser_OnUserMediaSet_CommentQueryService(
        UpsertUser_OnUserMediaSet_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<UserMediaSetEvent>
    {
        public Task Consume(ConsumeContext<UserMediaSetEvent> context) =>
            userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

using MassTransit;
using Shared.Events.PostService;
using UserQueryService.Shared.Model;

namespace UserQueryService.Worker.Consumers.DecreasePostCountOnPostCreated
{
    internal class DecreasePostCount_OnPostCreated_UserQueryService(IUserRepository userRepository) : IConsumer<PostSoftDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostSoftDeletedEvent> context) =>
            userRepository.DecreasePostCount(context.Message.UserId, context.CancellationToken);
    }
}

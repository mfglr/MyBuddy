using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.PostLikeService;

namespace PostQueryService.Worker.Consumers.DecreasePostLikeCount
{
    internal class DecreasePostLikeCount_OnPostDisliked_PostQueryService(IPostRepository postRepository) : IConsumer<PostDislikedEvent>
    {
        public Task Consume(ConsumeContext<PostDislikedEvent> context) =>
            postRepository.DecreaseLikeCount(context.Message.PostId, context.CancellationToken);
    }
}

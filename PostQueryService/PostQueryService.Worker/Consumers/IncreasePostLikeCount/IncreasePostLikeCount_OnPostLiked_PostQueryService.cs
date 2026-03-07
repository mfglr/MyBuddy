using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.PostLikeService;

namespace PostQueryService.Worker.Consumers.IncreasePostLikeCount
{
    internal class IncreasePostLikeCount_OnPostLiked_PostQueryService(IPostRepository postRepository) : IConsumer<PostLikedEvent>
    {
        public Task Consume(ConsumeContext<PostLikedEvent> context) =>
            postRepository.IncreaseLikeCount(context.Message.PostId,context.CancellationToken);
    }
}

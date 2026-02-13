using MassTransit;
using MediatR;
using Shared.Events.PostLikeService;

namespace PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostDisliked
{
    internal class UpgradePostLiked_OnPostDisliked_PostLikeQueryService(ISender sender, Mapper mapper) : IConsumer<PostDislikedEvent>
    {
        public Task Consume(ConsumeContext<PostDislikedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

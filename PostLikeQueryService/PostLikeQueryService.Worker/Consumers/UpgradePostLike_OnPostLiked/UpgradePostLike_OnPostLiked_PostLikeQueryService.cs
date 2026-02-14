using MassTransit;
using MediatR;
using Shared.Events.PostLikeService;

namespace PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostLiked
{
    internal class UpgradePostLike_OnPostLiked_PostLikeQueryService(ISender sender, UpgradePostLike_OnPostLiked_Mapper mapper) : IConsumer<PostLikedEvent>
    {
        public Task Consume(ConsumeContext<PostLikedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

using MassTransit;
using PostLikeQueryService.Shared.Model;
using Shared.Events.PostLikeService;

namespace PostLikeQueryService.Worker.Consumers.UpsertPostUserLike_OnPostLiked
{
    internal class UpsertPostUserLike_OnPostLiked_PostLikeQueryService(
        IPostUserLikeRepository repository,
        UpsertPostUserLike_OnPostLiked_Mapper mapper
    ) : IConsumer<PostLikedEvent>
    {
        public Task Consume(ConsumeContext<PostLikedEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

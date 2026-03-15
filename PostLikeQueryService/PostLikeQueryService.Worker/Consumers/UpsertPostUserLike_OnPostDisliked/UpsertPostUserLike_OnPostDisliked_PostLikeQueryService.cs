using MassTransit;
using PostLikeQueryService.Shared.Model;
using Shared.Events.PostLikeService;

namespace PostLikeQueryService.Worker.Consumers.UpsertPostUserLike_OnPostDisliked
{
    internal class UpsertPostUserLike_OnPostDisliked_PostLikeQueryService(
        IPostUserLikeRepository repository,
        UpsertPostUserLike_OnPostDisliked_Mapper mapper
    ) : IConsumer<PostDislikedEvent>
    {
        public Task Consume(ConsumeContext<PostDislikedEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPostOnPostRestored
{
    internal class UpsertPost_OnPostRestored_PostQueryService(
        UpsertPost_OnPostRestored_Mapper mapper,
        IPostRepository postRepository
    ) : IConsumer<PostRestoredEvent>
    {
        public Task Consume(ConsumeContext<PostRestoredEvent> context) =>
            postRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

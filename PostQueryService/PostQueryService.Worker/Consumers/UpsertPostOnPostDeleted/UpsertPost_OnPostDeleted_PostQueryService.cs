using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPostOnPostDeleted
{
    internal class UpsertPost_OnPostDeleted_PostQueryService(
        UpsertPost_OnPostDeleted_Mapper mapper,
        IPostRepository postRepository
    ) : IConsumer<PostDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostDeletedEvent> context) =>
            postRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

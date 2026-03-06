using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPostOnPostRestored
{
    internal class UpsertPost_OnPostRestored_PostQueryService(UpsertPost_OnPostRestored_Mapper mapper, IPostRepository postRepository) : IConsumer<PostRestoredEvent>
    {
        public Task Consume(ConsumeContext<PostRestoredEvent> context)
        {
            if (!context.Message.IsValidVersion) return Task.CompletedTask;
            var post = mapper.Map(context.Message);
            return postRepository.UpsertAsync(post, context.CancellationToken);
        }
    }
}

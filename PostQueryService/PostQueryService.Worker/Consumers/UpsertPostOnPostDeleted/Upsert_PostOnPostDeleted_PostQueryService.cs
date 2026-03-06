using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPostOnPostDeleted
{
    internal class Upsert_PostOnPostDeleted_PostQueryService(UpsertPost_OnPostDeleted_Mapper mapper, IPostRepository postRepository) : IConsumer<PostDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostDeletedEvent> context)
        {
            if (!context.Message.IsValidVersion) return Task.CompletedTask;
            var post = mapper.Map(context.Message);
            return postRepository.UpsertAsync(post, context.CancellationToken);
        }
    }
}

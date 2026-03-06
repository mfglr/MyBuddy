using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPostOnPostContentModerationResultSet
{
    internal class UpsertPost_OnPostContentModerationResultSet_PostQueryService(
        UpsertPost_OnPostContentModerationResultSet_Mapper mapper, IPostRepository postRepository
    ) : IConsumer<PostContentModerationResultSetEvent>
    {
        public Task Consume(ConsumeContext<PostContentModerationResultSetEvent> context)
        {
            if (!context.Message.IsValidVersion) return Task.CompletedTask;
            var post = mapper.Map(context.Message);
            return postRepository.UpsertAsync(post, context.CancellationToken);
        }
    }
}

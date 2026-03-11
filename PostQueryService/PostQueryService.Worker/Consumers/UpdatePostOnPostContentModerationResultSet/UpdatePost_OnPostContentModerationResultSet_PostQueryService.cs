using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpdatePostOnPostContentModerationResultSet
{
    internal class UpdatePost_OnPostContentModerationResultSet_PostQueryService(
        UpdatePost_OnPostContentModerationResultSet_Mapper mapper,
        IPostRepository postRepository
    ) : IConsumer<PostContentModerationResultSetEvent>
    {
        public Task Consume(ConsumeContext<PostContentModerationResultSetEvent> context) =>
            postRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

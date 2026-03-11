using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpserPostOnPostCreated
{
    internal class UpsertPost_OnPostCreated_PostQueryService(
        IPostRepository postRepository,
        UpsertPost_OnPostCreated_Mapper mapper
    ) : IConsumer<PostCreatedEvent>
    {
        public Task Consume(ConsumeContext<PostCreatedEvent> context) =>
            postRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

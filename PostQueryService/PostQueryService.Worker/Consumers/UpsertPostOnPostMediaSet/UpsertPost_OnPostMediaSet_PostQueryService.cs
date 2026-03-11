using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPostOnPostMediaSet
{
    internal class UpsertPost_OnPostMediaSet_PostQueryService(
        UpsertPost_OnPostMediaSet_Mapper mapper,
        IPostRepository postRepository
    ) : IConsumer<PostMediaSetEvent>
    {
        public Task Consume(ConsumeContext<PostMediaSetEvent> context) =>
            postRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

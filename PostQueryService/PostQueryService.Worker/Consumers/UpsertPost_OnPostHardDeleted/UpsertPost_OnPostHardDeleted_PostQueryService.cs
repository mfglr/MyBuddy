using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPost_OnPostHardDeleted
{
    internal class UpsertPost_OnPostHardDeleted_PostQueryService(
        ISender sender,
        UpsertPost_OnPostHardDeleted_Mapper mapper
    ) : IConsumer<PostHardDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostHardDeletedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

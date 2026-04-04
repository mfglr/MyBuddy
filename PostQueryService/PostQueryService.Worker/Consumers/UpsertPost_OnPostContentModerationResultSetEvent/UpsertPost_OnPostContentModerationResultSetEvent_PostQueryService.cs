using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPost_OnPostContentModerationResultSetEvent
{
    internal class UpsertPost_OnPostContentModerationResultSetEvent_PostQueryService(
        ISender sender,
        UpsertPost_OnPostContentModerationResultSetEvent_Mapper mapper
    ) : IConsumer<PostContentModerationResultSetEvent>
    {
        public Task Consume(ConsumeContext<PostContentModerationResultSetEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPost_OnPostContentUpdated
{
    internal class UpsertPost_OnPostContentUpdated_PostQueryService(
        ISender sender,
        UpsertPost_OnPostContentUpdated_Mapper mapper
    ) : IConsumer<PostContentUpdatedEvent>
    {
        public Task Consume(ConsumeContext<PostContentUpdatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

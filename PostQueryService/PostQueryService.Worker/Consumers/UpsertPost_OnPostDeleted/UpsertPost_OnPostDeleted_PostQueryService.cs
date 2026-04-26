using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPost_OnPostDeleted
{
    internal class UpsertPost_OnPostDeleted_PostQueryService(
        ISender sender,
        UpsertPost_OnPostDeleted_Mapper mapper
    ) : IConsumer<PostDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostDeletedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

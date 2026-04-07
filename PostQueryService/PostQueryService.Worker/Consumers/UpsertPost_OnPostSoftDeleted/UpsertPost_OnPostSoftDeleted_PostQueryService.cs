using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpsertPost_OnPostSoftDeleted
{
    internal class UpsertPost_OnPostSoftDeleted_PostQueryService(
        ISender sender,
        UpsertPost_OnPostSoftDeleted_Mapper mapper
    ) : IConsumer<PostSoftDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostSoftDeletedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

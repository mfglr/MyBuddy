using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnContentUpdated
{
    internal class UpsertComment_OnContentUpdated_CommentQueryService(
        ISender sender,
        UpsertComment_OnContentUpdated_Mapper mapper
    ) : IConsumer<CommentContentUpdatedEvent>
    {
        public Task Consume(ConsumeContext<CommentContentUpdatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

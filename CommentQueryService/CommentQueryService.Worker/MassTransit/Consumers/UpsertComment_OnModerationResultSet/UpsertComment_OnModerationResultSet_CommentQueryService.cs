using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnModerationResultSet
{
    internal class UpsertComment_OnModerationResultSet_CommentQueryService(
        UpsertComment_OnModerationResultSet_Mapper mapper,
        ISender sender
    ) : IConsumer<CommentContentModerationResultSetEvent>
    {
        public Task Consume(ConsumeContext<CommentContentModerationResultSetEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

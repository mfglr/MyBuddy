using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateComment_OnModerationResultSet
{
    internal class UpdateComment_OnModerationResultSet_CommentQueryService(
        UpdateComment_OnModerationResultSet_Mapper mapper,
        ISender sender
    ) : IConsumer<CommentContentModerationResultSetEvent>
    {
        public Task Consume(ConsumeContext<CommentContentModerationResultSetEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnCommentDeleted
{
    internal class UpsertComment_OnCommentDeleted_CommentQueryService(
        ISender sender,
        UpsertComment_OnCommentDeleted_Mapper mapper
    ) : IConsumer<CommentDeletedEvent>
    {
        public Task Consume(ConsumeContext<CommentDeletedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnCommentCreated
{
    internal class UpsertComment_OnCommentCreated_CommentQueryService(
        ISender sender,
        UpsertComment_OnCommentCreated_Mapper mapper
    ) : IConsumer<CommentCreatedEvent>
    {
        public Task Consume(ConsumeContext<CommentCreatedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

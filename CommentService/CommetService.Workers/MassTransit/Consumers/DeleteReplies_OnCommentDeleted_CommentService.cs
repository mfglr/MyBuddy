using CommentService.Application.UseCases.DeleteComentReplies;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommetService.Workers.MassTransit.Consumers
{
    internal class DeleteReplies_OnCommentDeleted_CommentService(ISender sender) : IConsumer<CommentDeletedEvent>
    {
        public Task Consume(ConsumeContext<CommentDeletedEvent> context) =>
            sender.Send(new DeleteCommentRepliesRequest(context.Message.Id),context.CancellationToken);
    }
}

using CommentService.Application.UseCases.DeleteComentReplies;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommetService.Workers.Consumers
{
    internal class DeleteRepliesConsumer_CommentService(ISender sender) : IConsumer<CommentDeletedEvent>
    {
        private readonly ISender _sender = sender;
        public Task Consume(ConsumeContext<CommentDeletedEvent> context) =>
            _sender.Send(new DeleteCommentRepliesRequest(context.Message.Id));
    }
}

using CommentService.Application.UseCases.DeleteComment;
using MassTransit;
using MassTransit.Mediator;
using Shared.Events.Comment;

namespace CommetService.Workers.Consumers.DeleteRepliesOnCommentDeleted
{
    internal class DeleteRepliesOnCommentDeleted(IMediator mediator) : IConsumer<CommentDeletedEvent>
    {
        private readonly IMediator _mediator = mediator;

        public Task Consume(ConsumeContext<CommentDeletedEvent> context)
        {
        }
    }
}

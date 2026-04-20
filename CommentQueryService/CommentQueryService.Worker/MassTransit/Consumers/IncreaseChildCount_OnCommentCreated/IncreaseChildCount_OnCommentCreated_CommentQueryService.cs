using CommentQueryService.Domain.CommentAggregate;
using MassTransit;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.IncreaseChildCount_OnCommentCreated
{
    internal class IncreaseChildCount_OnCommentCreated_CommentQueryService(
        ICommentRepository repository
    ) : IConsumer<CommentCreatedEvent>
    {
        public Task Consume(ConsumeContext<CommentCreatedEvent> context) =>
            context.Message.ParentId != null
                ? repository.IncreaseChildCount((Guid)context.Message.ParentId, context.CancellationToken)
                : Task.CompletedTask;
    }
}

using CommentQueryService.Domain;
using MassTransit;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.DecreaseChildCount_OnCommentDeleted
{
    internal class DecreaseChildCount_OnCommentDeleted_CommentQueryService(ICommentProjectionRepository repository) : IConsumer<CommentDeletedEvent>
    {
        public Task Consume(ConsumeContext<CommentDeletedEvent> context) =>
            context.Message.ParentId != null
                ? repository.DecreaseChildCount((Guid)context.Message.ParentId, context.CancellationToken)
                : Task.CompletedTask;
    }
}

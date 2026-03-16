using CommentQueryService.Shared.Model;
using MassTransit;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnCommentDeleted
{
    internal class UpsertComment_OnCommentDeleted_CommentQueryService(
        ICommentRepository repository,
        UpsertComment_OnCommentDeleted_Mapper mapper
    ) : IConsumer<CommentDeletedEvent>
    {
        public Task Consume(ConsumeContext<CommentDeletedEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

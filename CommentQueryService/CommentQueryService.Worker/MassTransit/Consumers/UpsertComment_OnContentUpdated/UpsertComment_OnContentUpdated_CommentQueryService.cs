using CommentQueryService.Shared.Model;
using MassTransit;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnContentUpdated
{
    internal class UpsertComment_OnContentUpdated_CommentQueryService(
        ICommentRepository repository,
        UpsertComment_OnContentUpdated_Mapper mapper
    ) : IConsumer<CommentContentUpdatedEvent>
    {
        public Task Consume(ConsumeContext<CommentContentUpdatedEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

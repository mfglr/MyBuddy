using CommentQueryService.Shared.Model;
using MassTransit;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnModerationResultSet
{
    internal class UpsertComment_OnModerationResultSet_CommentQueryService(
        UpsertComment_OnModerationResultSet_Mapper mapper,
        ICommentRepository repository
    ) : IConsumer<CommentContentModerationResultSetEvent>
    {
        public Task Consume(ConsumeContext<CommentContentModerationResultSetEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}

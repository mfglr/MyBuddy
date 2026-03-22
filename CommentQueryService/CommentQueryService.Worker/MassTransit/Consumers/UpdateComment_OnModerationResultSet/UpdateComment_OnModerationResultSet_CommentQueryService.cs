using CommentQueryService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateComment_OnModerationResultSet
{
    internal class UpdateComment_OnModerationResultSet_CommentQueryService(
        UpdateComment_OnModerationResultSet_Mapper mapper,
        ISender sender
    ) : IConsumer<CommentContentModerationResultSetEvent>
    {
        public async Task Consume(ConsumeContext<CommentContentModerationResultSetEvent> context)
        {
            try
            {
                await sender.Send(mapper.Map(context.Message), context.CancellationToken);
            }
            catch (OutdatedVersionException)
            {
                return;
            }
        }
    }
}

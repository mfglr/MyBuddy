using CommentQueryService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateComment_OnCommentDeleted
{
    internal class UpdateComment_OnCommentDeleted_CommentQueryService(
        ISender sender,
        UpdateComment_OnCommentDeleted_Mapper mapper
    ) : IConsumer<CommentDeletedEvent>
    {
        public async Task Consume(ConsumeContext<CommentDeletedEvent> context)
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

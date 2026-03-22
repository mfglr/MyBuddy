using CommentQueryService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommentQueryService.Worker.MassTransit.Consumers.UpdateComment_OnContentUpdated
{
    internal class UpdateComment_OnContentUpdated_CommentQueryService(
        ISender sender,
        UpdateComment_OnContentUpdated_Mapper mapper
    ) : IConsumer<CommentContentUpdatedEvent>
    {
        public async Task Consume(ConsumeContext<CommentContentUpdatedEvent> context)
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

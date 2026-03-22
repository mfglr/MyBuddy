using CommentLikeQueryService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.CommentLikeService;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateComment_OnCommentLiked
{
    internal class UpdateComment_OnCommentLiked_CommentLikeQueryService(
        ISender sender,
        UpdateComment_OnCommentLiked_Mapper mapper
    ) : IConsumer<CommentLikedEvent>
    {
        public async Task Consume(ConsumeContext<CommentLikedEvent> context)
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

using CommentLikeQueryService.Domain;
using MassTransit;
using MediatR;
using Shared.Events.CommentLikeService;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateComment_OnCommentDisliked
{
    internal class UpdateComment_OnCommentDisliked_CommentLikeQueryService(
        ISender sender,
        UpdateComment_OnCommentDisliked_Mapper mapper
    ) : IConsumer<CommentDislikedEvent>
    {
        public async Task Consume(ConsumeContext<CommentDislikedEvent> context)
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

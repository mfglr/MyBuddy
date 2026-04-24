using MassTransit;
using MediatR;
using Shared.Events.CommentLikeService;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.CreateCommentLike_OnCommentLiked
{
    internal class CreateCommentLike_OnCommentLiked_CommentLikeQueryService(
        ISender sender,
        CreateCommentLike_OnCommentLiked_Mapper mapper
    ) : IConsumer<CommentLikedEvent>
    {
        public Task Consume(ConsumeContext<CommentLikedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

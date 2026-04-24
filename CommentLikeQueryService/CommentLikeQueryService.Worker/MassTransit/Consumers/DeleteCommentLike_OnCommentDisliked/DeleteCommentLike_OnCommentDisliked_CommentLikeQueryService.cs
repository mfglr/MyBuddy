using MassTransit;
using MediatR;
using Shared.Events.CommentLikeService;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.DeleteCommentLike_OnCommentDisliked
{
    internal class DeleteCommentLike_OnCommentDisliked_CommentLikeQueryService(
        ISender sender,
        DeleteCommentLike_OnCommentDisliked_Mapper mapper
    ) : IConsumer<CommentDislikedEvent>
    {
        public Task Consume(ConsumeContext<CommentDislikedEvent> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}

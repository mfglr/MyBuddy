using CommentQueryService.Domain;
using MassTransit;
using Shared.Events.CommentLikeService;

namespace CommentQueryService.Worker.MassTransit.Consumers.IncreaseLikeCount_OnCommentLiked
{
    internal class IncreaseLikeCount_OnCommentLiked_CommentQueryService(ICommentProjectionRepository repository) : IConsumer<CommentLikedEvent>
    {
        public Task Consume(ConsumeContext<CommentLikedEvent> context) =>
            repository.IncreaseLikeCount(context.Message.CommentId, context.CancellationToken);
    }
}

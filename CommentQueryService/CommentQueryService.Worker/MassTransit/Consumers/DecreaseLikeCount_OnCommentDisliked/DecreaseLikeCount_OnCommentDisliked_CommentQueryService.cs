using CommentQueryService.Domain;
using MassTransit;
using Shared.Events.CommentLikeService;

namespace CommentQueryService.Worker.MassTransit.Consumers.DecreaseLikeCount_OnCommentDisliked
{
    internal class DecreaseLikeCount_OnCommentDisliked_CommentQueryService(ICommentProjectionRepository repository) : IConsumer<CommentDislikedEvent>
    {
        public Task Consume(ConsumeContext<CommentDislikedEvent> context) =>
            repository.DecreaseLikeCount(context.Message.CommentId, context.CancellationToken);
    }
}

using CommentLikeService.Domain;
using MassTransit;
using MediatR;

namespace CommentLikeService.Application.UseCases.DislikeComment
{
    internal class DislikeCommentHandler(
        ICommentLikeRepository repository,
        IAuthService authService,
        DislikeCommentMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<DislikeCommentRequest>
    {
        public async Task Handle(DislikeCommentRequest request, CancellationToken cancellationToken)
        {
            var commentLikeId = new CommentLikeId(request.CommentId, authService.UserId);
            var like = 
                await repository.GetCommentByIdAsync(commentLikeId, cancellationToken) ??
                throw new CommentLikeNotAvailableException();
            like.Dislike();
            await repository.UpdateAsync(like, cancellationToken);

            var @event = mapper.Map(like);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}

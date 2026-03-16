using CommentLikeService.Domain;
using MassTransit;
using MediatR;

namespace CommentLikeService.Application.UseCases.LikeComment
{
    internal class LikeCommentHandler(
        ICommentLikeRepository repository,
        IPublishEndpoint publishEndpoint,
        LikeCommentMapper mapper,
        IAuthService authService

    ) : IRequestHandler<LikeCommentRequest>
    {
        public async Task Handle(LikeCommentRequest request, CancellationToken cancellationToken)
        {
            var id = new CommentLikeId(request.CommentId, authService.UserId);
            var like = await repository.GetCommentByIdAsync(id, cancellationToken);
            if (like == null)
            {
                like = new CommentLike(id);
                await repository.CreateAsync(like, cancellationToken);
            }
            else
            {
                like.Like();
                await repository.UpdateAsync(like, cancellationToken);
            }

            var @event = mapper.Map(like);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}

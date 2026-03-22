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
            var currentUser = authService.CurrentUser;
            var id = new CommentLikeId(request.CommentId, currentUser.Id);
            var like = await repository.GetByIdAsync(id, cancellationToken);
            if (like == null)
            {
                like = new CommentLike(id);
                await repository.CreateAsync(like, cancellationToken);
                var @event = mapper.MapCreatedEvent(like, currentUser);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            else
            {
                like.Like();
                await repository.UpdateAsync(like, cancellationToken);
                var @event = mapper.MapLikedEvent(like);
                await publishEndpoint.Publish(@event, cancellationToken);
            }

            
        }
    }
}

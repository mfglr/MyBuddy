using CommentLikeService.Domain;
using MassTransit;
using MediatR;

namespace CommentLikeService.Application.UseCases.LikeComment
{
    internal class LikeCommentHandler(
        CommentLikeDomainService commentLikeDomainService,
        ICommentLikeRepository repository,
        IPublishEndpoint publishEndpoint,
        LikeCommentMapper mapper,
        IAuthService authService

    ) : IRequestHandler<LikeCommentRequest>
    {
        public async Task Handle(LikeCommentRequest request, CancellationToken cancellationToken)
        {
            var id = new CommentLikeId(request.CommentId, authService.UserId);
            var like = await commentLikeDomainService.Like(id,cancellationToken);
            await repository.CreateAsync(like, cancellationToken);

            var @event = mapper.Map(like);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}

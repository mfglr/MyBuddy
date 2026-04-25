using MassTransit;
using MediatR;
using PostLikeService.Domain;

namespace PostLikeService.Application.UseCases.DislikePost
{
    internal class DislikePostHandler(
        IPostLikeRepository postLikeRepository,
        IPublishEndpoint publishEndpoint,
        DislikePostMapper mapper,
        IAuthService authService
    ) : IRequestHandler<DislikePostRequest>
    {
        public async Task Handle(DislikePostRequest request, CancellationToken cancellationToken)
        {
            var id = new PostLikeId(authService.UserId, request.PostId);
            var like =
                await postLikeRepository.GetByIdAsync(id, cancellationToken) ??
                throw new PostLikeNotFoundException();
            await postLikeRepository.DeleteAsync(like, cancellationToken);

            var @event = mapper.Map(like);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}

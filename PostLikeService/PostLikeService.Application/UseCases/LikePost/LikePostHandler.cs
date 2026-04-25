using MassTransit;
using MediatR;
using PostLikeService.Domain;

namespace PostLikeService.Application.UseCases.LikePost
{
    internal class LikePostHandler(
        LikePostMapper mapper,
        IPublishEndpoint publishEndpoint,
        IAuthService authService,
        IPostLikeRepository repository,
        PostLikeDomainService domainService
    ) : IRequestHandler<LikePostRequest>
    {
        public async Task Handle(LikePostRequest request, CancellationToken cancellationToken)
        {
            var id = new PostLikeId(authService.UserId, request.PostId);
            var like = await domainService.Like(id, cancellationToken);
            await repository.CreateAsync(like, cancellationToken);

            var @event = mapper.Map(like);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}

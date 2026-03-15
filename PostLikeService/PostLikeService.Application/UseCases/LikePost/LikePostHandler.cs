using MassTransit;
using MediatR;
using PostLikeService.Domain;

namespace PostLikeService.Application.UseCases.LikePost
{
    internal class LikePostHandler(
        LikePostMapper mapper,
        IPublishEndpoint publishEndpoint,
        IAuthService authService,
        IPostLikeRepository postRepository
    ) : IRequestHandler<LikePostRequest>
    {
        public async Task Handle(LikePostRequest request, CancellationToken cancellationToken)
        {
            var id = new PostLikeId(authService.UserId, request.PostId);
            var like = await postRepository.GetAsync(id, cancellationToken);
            if(like != null)
            {
                like.Like();
                await postRepository.UpdateAsync(like, cancellationToken);
            }
            else
            {
                like = new PostLike(id);
                await postRepository.CreateAsync(like, cancellationToken);
            }

            var @event = mapper.Map(like);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}

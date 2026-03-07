using MassTransit;
using MediatR;
using PostLikeService.Domain;

namespace PostLikeService.Application.UseCases.DislikePost
{
    internal class DislikePostHandler(IPostLikeRepository postLikeRepository, IPublishEndpoint publishEndpoint, DislikePostMapper mapper, IIdentityService identiytService) : IRequestHandler<DislikePostRequest>
    {
        public async Task Handle(DislikePostRequest request, CancellationToken cancellationToken)
        {
            var id = new PostLikeId(identiytService.UserId, request.PostId);
            var like =
                await postLikeRepository.GetAsync(id, cancellationToken) ??
                throw new PostNotLikedBeforeException();
            like.Dislike();
            await postLikeRepository.UpdateAsync(like, cancellationToken);

            var @event = mapper.Map(like);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}

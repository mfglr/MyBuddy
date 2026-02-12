using AutoMapper;
using MassTransit;
using MediatR;
using PostLikeService.Domain;
using Shared.Events.PostLikeService;

namespace PostLikeService.Application.UseCases.DislikePost
{
    internal class DislikePostHandler(IPostLikeRepository postLikeRepository, IPublishEndpoint publishEndpoint, IMapper mapper, IIdentityService identiytService) : IRequestHandler<DislikePostRequest>
    {
        public async Task Handle(DislikePostRequest request, CancellationToken cancellationToken)
        {
            var id = new PostLikeId(identiytService.UserId, request.PostId);
            var like =
                await postLikeRepository.GetAsync(id, cancellationToken) ??
                throw new PostNotLikedBeforeException();

            await postLikeRepository.DeleteAsync(like, cancellationToken);

            var @event = mapper.Map<PostLike, PostDislikedEvent>(like);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}

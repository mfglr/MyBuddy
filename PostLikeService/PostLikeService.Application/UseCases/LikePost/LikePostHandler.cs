using AutoMapper;
using MassTransit;
using MediatR;
using PostLikeService.Domain;
using Shared.Events.PostLikeService;

namespace PostLikeService.Application.UseCases.LikePost
{
    internal class LikePostHandler(IMapper mapper, IPublishEndpoint publishEndpoint, IIdentityService identiytService, IPostLikeRepository postRepository) : IRequestHandler<LikePostRequest>
    {
        public async Task Handle(LikePostRequest request, CancellationToken cancellationToken)
        {
            var id = new PostLikeId(identiytService.UserId, request.PostId);
            if (await postRepository.ExistAsync(id, cancellationToken))
                throw new PostAlreadyLikedException();
            
            var like = new PostLike(id);
            await postRepository.CreateAsync(like, cancellationToken);

            var @event = mapper.Map<PostLike, PostLikedEvent>(like);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}

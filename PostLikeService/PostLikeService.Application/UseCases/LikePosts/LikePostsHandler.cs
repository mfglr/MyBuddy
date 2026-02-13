using AutoMapper;
using MassTransit;
using MediatR;
using PostLikeService.Domain;
using Shared.Events.PostLikeService;

namespace PostLikeService.Application.UseCases.LikePosts
{
    internal class LikePostsHandler(IMapper mapper, IPublishEndpoint publishEndpoint, IPostLikeRepository postLikeRepository) : IRequestHandler<LikesPostsRequest>
    {
        public async Task Handle(LikesPostsRequest request, CancellationToken cancellationToken)
        {
            var likes = await postLikeRepository.GetByPostIdAsync(request.PostId, cancellationToken);
            foreach (var like in likes)
                like.Like();
            await postLikeRepository.UpdateAsync(likes, cancellationToken);

            var events = mapper.Map<IEnumerable<PostLike>, IEnumerable<PostLikedEvent>>(likes);
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}

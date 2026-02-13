using AutoMapper;
using MassTransit;
using MediatR;
using PostLikeService.Domain;
using Shared.Events.PostLikeService;

namespace PostLikeService.Application.UseCases.DislikePosts
{
    internal class DislikePostsHandler(IMapper mapper, IPublishEndpoint publishEndpoint, IPostLikeRepository postLikeRepository) : IRequestHandler<DislikesPostsRequest>
    {
        public async Task Handle(DislikesPostsRequest request, CancellationToken cancellationToken)
        {
            var likes = await postLikeRepository.GetByPostIdAsync(request.PostId, cancellationToken);
            foreach (var like in likes)
                like.Dislike();
            await postLikeRepository.UpdateAsync(likes, cancellationToken);

            var events = mapper.Map<IEnumerable<PostLike>, IEnumerable<PostDislikedEvent>>(likes);
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}

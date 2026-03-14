using MassTransit;
using MediatR;
using PostLikeService.Domain;

namespace PostLikeService.Application.UseCases.LikePosts
{
    internal class LikePostsHandler(LikePostsMapper mapper, IPublishEndpoint publishEndpoint, IPostLikeRepository postLikeRepository) : IRequestHandler<LikesPostsRequest>
    {
        public async Task Handle(LikesPostsRequest request, CancellationToken cancellationToken)
        {
            var likes = await postLikeRepository.GetByPostIdAsync(request.PostId, cancellationToken);
            if (likes.Count == 0) return;

            foreach (var like in likes)
                like.Like();
            await postLikeRepository.UpdateAsync(likes, cancellationToken);

            var events = likes.Select(mapper.Map);
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}

using MassTransit;
using MediatR;
using PostLikeService.Domain;

namespace PostLikeService.Application.UseCases.DislikePosts
{
    internal class DislikePostsHandler(DislikePostsMapper mapper, IPublishEndpoint publishEndpoint, IPostLikeRepository postLikeRepository) : IRequestHandler<DislikesPostsRequest>
    {
        public async Task Handle(DislikesPostsRequest request, CancellationToken cancellationToken)
        {
            var likes = await postLikeRepository.GetByPostIdAsync(request.PostId, cancellationToken);
            if (likes.Count == 0) return;

            foreach (var like in likes)
                like.Dislike();
            await postLikeRepository.UpdateAsync(likes, cancellationToken);

            var events = likes.Select(mapper.Map);
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}

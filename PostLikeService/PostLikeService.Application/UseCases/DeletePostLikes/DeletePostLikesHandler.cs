using MediatR;
using PostLikeService.Domain;

namespace PostLikeService.Application.UseCases.DeletePostLikes
{
    internal class DeletePostLikesHandler(IPostLikeRepository postLikeRepository) : IRequestHandler<DeletePostLikesRequest>
    {
        public async Task Handle(DeletePostLikesRequest request, CancellationToken cancellationToken)
        {
            var likes = await postLikeRepository.GetByPostIdAsync(request.PostId, cancellationToken);
            if (likes.Count == 0) return;
            await postLikeRepository.DeleteAsync(likes, cancellationToken);
        }
    }
}

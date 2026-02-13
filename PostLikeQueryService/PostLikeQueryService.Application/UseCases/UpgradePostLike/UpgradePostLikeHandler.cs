using MediatR;
using PostLikeQueryService.Domain.PostLikeAggregate;

namespace PostLikeQueryService.Application.UseCases.UpgradePostLike
{
    internal class UpgradePostLikeHandler(IUnitOfWork unitOfWork, IPostLikeRepository postLikeRepository) : IRequestHandler<UpgradePostLikeRequest>
    {
        public async Task Handle(UpgradePostLikeRequest request, CancellationToken cancellationToken)
        {
            var like = await postLikeRepository.GetAsync(request.UserId, request.PostId, cancellationToken);
            if (like != null && request.Version <= like.Version) return;
            if (like == null && request.IsDeleted) return;
            if(like != null && request.IsDeleted)
            {
                postLikeRepository.Delete(like);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            if(like == null)
            {
                like = new PostLike(request.UserId, request.PostId, request.Version, request.CreatedAt);
                await postLikeRepository.CreateAsync(like, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            like.Upgrade(request.Version);
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}

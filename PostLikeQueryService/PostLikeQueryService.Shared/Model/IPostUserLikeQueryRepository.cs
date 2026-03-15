using PostLikeQueryService.Shared.Dto;

namespace PostLikeQueryService.Shared.Model
{
    public interface IPostUserLikeQueryRepository
    {
        Task<List<PostUserLikeResponse>> GetByPostId(Guid postId, Guid? cursor, int pageSize, CancellationToken cancellationToken);
    }
}

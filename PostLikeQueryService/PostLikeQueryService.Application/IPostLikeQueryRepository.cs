namespace PostLikeQueryService.Application
{
    public interface IPostLikeQueryRepository
    {
        Task<List<PostLikeResponse>> GetLikesByPostId(Guid postId, Guid? cursor = null, int recordsPerPage = 20, CancellationToken cancellationToken = default);
    }
}

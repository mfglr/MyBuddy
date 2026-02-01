namespace PostQueryService.Application.QueryRepositories
{
    public interface IPostQueryRepository
    {
        Task<IEnumerable<PostResponse>> GetPostsByUserId(Guid userId, Page page, CancellationToken cancellationToken);
    }
}

namespace PostQueryService.Shared.Model
{
    public interface IPostQueryRepository
    {
        Task<List<PostResponse>> GetByUserId(Guid userId, Guid? cursor, int pageSize, CancellationToken cancellationToken);
    }
}

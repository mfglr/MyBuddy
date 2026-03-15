namespace PostLikeQueryService.Shared.Model
{
    public interface IPostUserLikeRepository
    {
        Task<int> UpsertAsync(PostUserLike postUserLike, CancellationToken cancellationToken);
    }
}

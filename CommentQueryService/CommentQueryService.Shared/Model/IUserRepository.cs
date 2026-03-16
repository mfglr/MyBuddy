namespace CommentQueryService.Shared.Model
{
    public interface IUserRepository
    {
        Task<int> UpsertAsync(User user, CancellationToken cancellationToken);
    }
}

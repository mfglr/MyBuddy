using UserQueryService.Application.UseCases.GetByUserName;

namespace UserQueryService.Application
{
    public interface IUserQueryRepository
    {
        Task<GetByUserNameResponse?> GetByUserNameAsync(string userName, CancellationToken cancelToken);
    }
}

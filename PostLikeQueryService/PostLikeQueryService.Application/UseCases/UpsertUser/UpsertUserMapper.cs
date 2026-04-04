using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserMapper(MediaMapper mediaMapper)
    {
        public User Map(UpsertUserRequest request) =>
            new(
                request.Id,
                request.Version,
                request.DeletedAt,
                request.Name,
                request.UserName,
                request.Media != null ? mediaMapper.Map(request.Media) : null
            );
    }
}

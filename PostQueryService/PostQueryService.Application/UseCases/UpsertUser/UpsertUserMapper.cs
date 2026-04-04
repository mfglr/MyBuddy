using PostQueryService.Domain.UserAggregate;

namespace PostQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserMapper(MediaMapper mediaMapper)
    {
        public User Map(UpsertUserRequest request) =>
            new(
                request.Id,
                request.DeletedAt,
                request.Version,
                request.Name,
                request.UserName,
                request.Media != null ? mediaMapper.Map(request.Media) : null
            );
    }
}

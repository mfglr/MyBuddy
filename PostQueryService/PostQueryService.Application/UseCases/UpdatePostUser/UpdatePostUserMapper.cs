using PostQueryService.Domain.PostProjectionAggregate;

namespace PostQueryService.Application.UseCases.UpdatePostUser
{
    internal class UpdatePostUserMapper(MediaMapper mediaMapper)
    {
        public PostProjectionUser Map(UpdatePostUserRequest request) =>
            new(
                request.Version,
                request.Name,
                request.UserName,
                request.Media != null ? mediaMapper.Map(request.Media) : null
            );
    }
}

using MediatR;
using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserHandler(
        IUserRepository userRepository,
        UpsertUserMapper userMapper
    ) : IRequestHandler<UpsertUserRequest>
    {
        public async Task Handle(UpsertUserRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                user = userMapper.Map(request);
                await userRepository.CreateAync(user, cancellationToken);
            }
            else
            {
                var updated = user.TryUpdate(
                    request.Version,
                    request.Name,
                    request.UserName,
                    request.Media != null ? userMapper.Map(request.Media) : null
                );
                if(updated)
                    await userRepository.UpdateAsync(user, cancellationToken);
            }
        }
            
    }
}

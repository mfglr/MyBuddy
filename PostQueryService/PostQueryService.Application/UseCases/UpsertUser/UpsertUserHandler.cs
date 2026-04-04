using MediatR;
using PostQueryService.Domain;
using PostQueryService.Domain.UserAggregate;

namespace PostQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserHandler(
        IUserRepository userRepository,
        UpsertUserMapper userMapper,
        MediaMapper mediaMapper
    ) : IRequestHandler<UpsertUserRequest>
    {
        public async Task Handle(UpsertUserRequest request, CancellationToken cancellationToken)
        {
            var (user, primaryTerm, sequenceNumber) = await userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                user = userMapper.Map(request);
                await userRepository.CreateAync(user, cancellationToken);
            }
            else
            {
                var updated = user.TryUpdateUser(
                    request.DeletedAt,
                    request.Version,
                    request.Name,
                    request.UserName,
                    request.Media != null ? mediaMapper.Map(request.Media) : null
                );
                if(updated)
                    await userRepository.UpdateAsync(user, primaryTerm, sequenceNumber, cancellationToken);
            }
        }
            
    }
}

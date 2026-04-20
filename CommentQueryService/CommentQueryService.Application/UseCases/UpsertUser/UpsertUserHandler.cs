using CommentQueryService.Domain.UserAggregate;
using MediatR;

namespace CommentQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserHandler(
        IUserRepository userRepository,
        UpsertUserMapper mapper
    ) : IRequestHandler<UpsertUserRequest>
    {
        public async Task Handle(UpsertUserRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                user = mapper.Map(request);
                await userRepository.CreateAsync(user, cancellationToken);
            }
            else
            {
                bool updated = user.TryUpdate(
                    request.DeletedAt,
                    request.Version,
                    request.Name,
                    request.UserName,
                    request.Media != null ? mapper.Map(request.Media) : null
                );

                if (updated)
                    await userRepository.UpdateAsync(user,cancellationToken);
            }
        }
    }
}

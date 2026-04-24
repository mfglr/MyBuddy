using CommentLikeQueryService.Domain.UserAggregate;
using MediatR;

namespace CommentLikeQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserHandler(
        IUserRepository repository,
        UpsertUserMapper mapper
    ) : IRequestHandler<UpsertUserRequest>
    {
        public async Task Handle(UpsertUserRequest request, CancellationToken cancellationToken)
        {
            var user = await repository.GetByIdAsync(request.Id, cancellationToken);

            if(user == null)
            {
                user = mapper.Map(request);
                await repository.CreateAsync(user, cancellationToken);
                return;
            }

            var updated = user.TryUpdate(
                request.Version,
                request.Name,
                request.UserName,
                request.Media != null ? mapper.Map(request.Media) : null
            );
            if(updated)
                await repository.UpdateAsync(user, cancellationToken);
        }
    }
}

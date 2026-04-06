using MediatR;
using PostQueryService.Domain.PostProjectionAggregate;
using PostQueryService.Domain.UserAggregate;

namespace PostQueryService.Application.UseCases.UpsertPost
{
    internal class UpsertPostHandler(
        IUserRepository userRepository,
        IPostProjectionRepository postProjectionRepository,
        UpsertPostMapper mapper
    ) : IRequestHandler<UpsertPostRequest>
    {
        public async Task Handle(UpsertPostRequest request, CancellationToken cancellationToken)
        {
            var (postProjection, primaryTerm, sequenceNumber) = await postProjectionRepository.GetByIdAsync(
                request.Id.ToString(),
                cancellationToken
            );

            if(postProjection == null)
            {
                var (user, _, _) = await userRepository.GetByIdAsync(request.UserId, cancellationToken);
                if (user == null)
                    throw new UserNotFoundException();

                postProjection = mapper.Map(request, user);
                await postProjectionRepository.CreateAsync(postProjection,cancellationToken);
            }
            else
            {
                var post = mapper.MapPost(request);
                if(postProjection.TryUpdatePost(post))
                    await postProjectionRepository.UpdateAsync((postProjection, primaryTerm, sequenceNumber), cancellationToken);
            }

        }
    }
}

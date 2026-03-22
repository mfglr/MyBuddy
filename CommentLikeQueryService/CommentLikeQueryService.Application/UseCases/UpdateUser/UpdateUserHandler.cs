using CommentLikeQueryService.Domain;
using MediatR;

namespace CommentLikeQueryService.Application.UseCases.UpdateUser
{
    internal class UpdateUserHandler(ICommentLikeProjectionRepository repository) : IRequestHandler<UpdateUserRequest>
    {
        public async Task Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var projections = 
                await repository.GetByUserAsync(request.User, cancellationToken) ??
                throw new ProjectionNotFoundException();

            foreach(var projection in projections)
                projection.UpdateUser(request.User);

            await repository.UpdateAsync(projections, cancellationToken);
        }
    }
}

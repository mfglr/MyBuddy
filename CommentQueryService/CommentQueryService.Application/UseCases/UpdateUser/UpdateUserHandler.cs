using CommentQueryService.Domain;
using MediatR;

namespace CommentQueryService.Application.UseCases.UpdateUser
{
    internal class UpdateUserHandler(ICommentProjectionRepository repository) : IRequestHandler<UpdateUserRequest>
    {
        public async Task Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var projections = await repository.GetByUserAsync(request.User, cancellationToken);
            foreach (var projection in projections)
                projection.UpdateUser(request.User);
            await repository.UpdateAsync(projections, cancellationToken);
        }
    }
}

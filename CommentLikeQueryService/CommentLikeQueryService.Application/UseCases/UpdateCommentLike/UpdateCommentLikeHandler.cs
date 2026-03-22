using CommentLikeQueryService.Domain;
using MediatR;

namespace CommentLikeQueryService.Application.UseCases.UpdateCommentLike
{
    internal class UpdateCommentLikeHandler(ICommentLikeProjectionRepository repository) : IRequestHandler<UpdateCommentLikeRequest>
    {
        public async Task Handle(UpdateCommentLikeRequest request, CancellationToken cancellationToken)
        {
            var projection = 
                await repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new ProjectionNotFoundException();
            projection.UpdateCommentLike(request.CommentLike);
            await repository.UpdateAsync(projection, cancellationToken);
        }
    }
}

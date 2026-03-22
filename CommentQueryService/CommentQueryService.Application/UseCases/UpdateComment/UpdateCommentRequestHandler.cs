using CommentQueryService.Domain;
using MediatR;

namespace CommentQueryService.Application.UseCases.UpdateComment
{
    internal class UpdateCommentRequestHandler(ICommentProjectionRepository repository) : IRequestHandler<UpdateCommentRequest>
    {
        public async Task Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
        {
            var projection =
                await repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new ProjectionNotFoundException();

            projection.UpdateComment(request.Comment);
            await repository.UpdateAsync(projection, cancellationToken);
        }
    }
}

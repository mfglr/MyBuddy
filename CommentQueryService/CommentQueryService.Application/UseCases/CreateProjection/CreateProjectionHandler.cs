using CommentQueryService.Domain;
using MediatR;

namespace CommentQueryService.Application.UseCases.CreateProjection
{
    internal class CreateProjectionHandler(ICommentProjectionRepository repository) : IRequestHandler<CreateProjectionRequest>
    {
        public Task Handle(CreateProjectionRequest request, CancellationToken cancellationToken)
        {
            var commentProjection = new CommentProjection(request.Id, request.Comment, request.User);
            return repository.CreateAsync(commentProjection, cancellationToken);
        }
    }
}

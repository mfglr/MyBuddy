using CommentLikeQueryService.Domain;
using MediatR;

namespace CommentLikeQueryService.Application.UseCases.CreateProjection
{
    internal class CreateProjectionHandler(ICommentLikeProjectionRepository repository) : IRequestHandler<CreateProjectionRequest>
    {
        public Task Handle(CreateProjectionRequest request, CancellationToken cancellationToken)
        {
            var projection = new CommentLikeProjection(request.Id, request.CommentLike, request.User);
            return repository.CreateAsync(projection, cancellationToken);
        }
    }
}

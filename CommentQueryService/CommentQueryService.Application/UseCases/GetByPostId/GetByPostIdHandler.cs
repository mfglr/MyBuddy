using CommentQueryService.Domain.CommentAggregate;
using MediatR;

namespace CommentQueryService.Application.UseCases.GetByPostId
{
    internal class GetByPostIdHandler(
        CommentResponseMapper mapper,
        ICommentRepository repository
    ) : IRequestHandler<GetByPostIdRequest, IEnumerable<CommentResponse>>
    {
        public async Task<IEnumerable<CommentResponse>> Handle(GetByPostIdRequest request, CancellationToken cancellationToken)
        {
            var comments = await repository.GetByPostIdAsync(request.PostId, request.Cursor, request.PageSize, cancellationToken);
            return comments.Select(mapper.Map);
        }
    }
}

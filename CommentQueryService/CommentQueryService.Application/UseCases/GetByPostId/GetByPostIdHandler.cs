using CommentQueryService.Domain;
using MediatR;

namespace CommentQueryService.Application.UseCases.GetByPostId
{
    internal class GetByPostIdHandler(
        CommentResponseMapper mapper,
        ICommentProjectionRepository repository
    ) : IRequestHandler<GetByPostIdRequest, IEnumerable<CommentResponse>>
    {
        public async Task<IEnumerable<CommentResponse>> Handle(GetByPostIdRequest request, CancellationToken cancellationToken)
        {
            var projections = await repository.GetByPostIdAsync(request.PostId, request.Cursor, request.PageSize, cancellationToken);
            return mapper.Map(projections);
        }
    }
}

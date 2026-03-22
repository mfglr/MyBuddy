using CommentQueryService.Domain;
using MediatR;

namespace CommentQueryService.Application.UseCases.GetByParentId
{
    internal class GetByParentIdHandler(
        CommentResponseMapper mapper,
        ICommentProjectionRepository repository
    ) : IRequestHandler<GetByParentIdRequest, IEnumerable<CommentResponse>>
    {
        public async Task<IEnumerable<CommentResponse>> Handle(GetByParentIdRequest request, CancellationToken cancellationToken)
        {
            var projections = await repository.GetByParentIdAsync(request.ParentId,request.Cursor,request.PageSize,cancellationToken);
            return mapper.Map(projections);
        }
    }
}

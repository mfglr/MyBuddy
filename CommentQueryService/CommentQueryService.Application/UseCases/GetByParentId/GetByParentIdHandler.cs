using CommentQueryService.Domain.CommentAggregate;
using MediatR;

namespace CommentQueryService.Application.UseCases.GetByParentId
{
    internal class GetByParentIdHandler(
        CommentResponseMapper mapper,
        ICommentRepository repository
    ) : IRequestHandler<GetByParentIdRequest, IEnumerable<CommentResponse>>
    {
        public async Task<IEnumerable<CommentResponse>> Handle(GetByParentIdRequest request, CancellationToken cancellationToken)
        {
            var comments = await repository.GetByParentIdAsync(request.ParentId,request.Cursor,request.PageSize,cancellationToken);
            return comments.Select(mapper.Map);
        }
    }
}

using MediatR;

namespace CommentQueryService.Application.UseCases.GetByParentId
{
    public record GetByParentIdRequest(Guid ParentId, Guid? Cursor, int PageSize) : IRequest<IEnumerable<CommentResponse>>;
}

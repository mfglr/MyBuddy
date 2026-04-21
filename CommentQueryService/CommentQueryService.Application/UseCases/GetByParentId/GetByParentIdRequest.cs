using MediatR;
using Shared;

namespace CommentQueryService.Application.UseCases.GetByParentId
{
    public record GetByParentIdRequest(Guid ParentId, int PageSize, PaginationKey<Guid?> Cursor) : IRequest<IEnumerable<CommentResponse>>;
}

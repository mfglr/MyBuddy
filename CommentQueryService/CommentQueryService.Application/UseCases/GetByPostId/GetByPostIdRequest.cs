using MediatR;
using Shared;

namespace CommentQueryService.Application.UseCases.GetByPostId
{
    public record GetByPostIdRequest(Guid PostId, int PageSize, PaginationKey<Guid?> Cursor) : IRequest<IEnumerable<CommentResponse>>;
}

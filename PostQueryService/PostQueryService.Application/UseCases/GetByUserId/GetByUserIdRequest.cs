using MediatR;
using Shared;

namespace PostQueryService.Application.UseCases.GetByUserId
{
    public record GetByUserIdRequest(string UserId, int PageSize, PaginationKey<string?> Cursor) : IRequest<IEnumerable<PostProjectionResponse>>;
}

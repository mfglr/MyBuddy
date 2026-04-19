using MediatR;

namespace PostQueryService.Application.UseCases.GetByUserId
{
    public record GetByUserIdRequest(string UserId, string? Cursor, int PageSize) : IRequest<IEnumerable<PostProjectionResponse>>;
}

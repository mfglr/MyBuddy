using MediatR;
using PostQueryService.Application.QueryRepositories;

namespace PostQueryService.Application.UseCases.GetPostsByUserId
{
    public record GetPostsByUserIdRequest(Guid UserId, DateTime Cursor, int RecordsPerPage, bool IsDescending) :
        Page(
            Cursor,
            RecordsPerPage,
            IsDescending
        ),
        IRequest<IEnumerable<PostResponse>>;
}

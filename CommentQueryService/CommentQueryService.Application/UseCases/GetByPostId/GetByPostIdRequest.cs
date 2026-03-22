using MediatR;

namespace CommentQueryService.Application.UseCases.GetByPostId
{
    public record GetByPostIdRequest(Guid PostId, Guid? Cursor, int PageSize) : IRequest<IEnumerable<CommentResponse>>;
}

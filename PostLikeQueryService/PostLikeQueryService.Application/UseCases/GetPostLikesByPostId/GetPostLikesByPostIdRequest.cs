using MediatR;

namespace PostLikeQueryService.Application.UseCases.GetPostLikesByPostId
{
    public record GetPostLikesByPostIdRequest(Guid PostId, Guid? Cursor, int RecordsPerPage) : IRequest<List<PostLikeResponse>>;
}

using MediatR;

namespace CommentLikeQueryService.Application.UseCases.GetByCommentId
{
    public record GetByCommentIdRequest(Guid CommentId, Guid? Cursor, int PageSize) : IRequest<List<CommentLikeResponse>>;
}

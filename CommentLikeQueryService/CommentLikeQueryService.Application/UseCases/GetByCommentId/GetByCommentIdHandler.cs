using CommentLikeQueryService.Domain;
using MediatR;

namespace CommentLikeQueryService.Application.UseCases.GetByCommentId
{
    internal class GetByCommentIdHandler(
        ICommentLikeProjectionRepository repository,
        CommentLikeResponseMapper mapper
    ) : IRequestHandler<GetByCommentIdRequest, List<CommentLikeResponse>>
    {
        public async Task<List<CommentLikeResponse>> Handle(GetByCommentIdRequest request, CancellationToken cancellationToken)
        {
            var projections = await repository.GetByCommentIdAsync(request.CommentId,request.Cursor,request.PageSize,cancellationToken);
            return mapper.Map(projections);
        }
    }
}

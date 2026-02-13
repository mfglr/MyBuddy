using MediatR;

namespace PostLikeQueryService.Application.UseCases.GetPostLikesByPostId
{
    internal class GetPostLikesByPostIdHandler(IPostLikeQueryRepository postLikeQueryRepository) : IRequestHandler<GetPostLikesByPostIdRequest, List<PostLikeResponse>>
    {
        public Task<List<PostLikeResponse>> Handle(GetPostLikesByPostIdRequest request, CancellationToken cancellationToken) =>
            postLikeQueryRepository.GetLikesByPostId(request.PostId,request.Cursor,request.RecordsPerPage, cancellationToken);
    }
}

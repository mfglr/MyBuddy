using MediatR;

namespace PostQueryService.Application.UseCases.GetByUserId
{
    internal class GetByUserIdHandler(
        IPostQueryRepository repository,
        GetByUserIdMapper mapper
    ) : IRequestHandler<GetByUserIdRequest, IEnumerable<PostProjectionResponse>>
    {
        public async Task<IEnumerable<PostProjectionResponse>> Handle(GetByUserIdRequest request, CancellationToken cancellationToken)
        {
            var posts = await repository.GetByUserIdAsync(request.UserId, request.PageSize, request.Cursor, cancellationToken);
            return posts.Select(mapper.Map);
        }
    }
}

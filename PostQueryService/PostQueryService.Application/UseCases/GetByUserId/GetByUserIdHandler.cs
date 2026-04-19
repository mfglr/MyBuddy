using MediatR;
using PostQueryService.Domain.PostProjectionAggregate;

namespace PostQueryService.Application.UseCases.GetByUserId
{
    internal class GetByUserIdHandler(
        IPostProjectionRepository postProjectionRepository,
        GetByUserIdMapper mapper
    ) : IRequestHandler<GetByUserIdRequest, IEnumerable<PostProjectionResponse>>
    {
        public async Task<IEnumerable<PostProjectionResponse>> Handle(GetByUserIdRequest request, CancellationToken cancellationToken)
        {
            var posts = await postProjectionRepository.GetByUserIdAsync(request.UserId, request.Cursor, request.PageSize, cancellationToken);
            return posts.Select(mapper.Map);
        }
    }
}

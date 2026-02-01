using MediatR;
using PostQueryService.Application.QueryRepositories;

namespace PostQueryService.Application.UseCases.GetPostsByUserId
{
    internal class GetPostsByUserIdHandler(IPostQueryRepository repository) : IRequestHandler<GetPostsByUserIdRequest, IEnumerable<PostResponse>>
    {
        public Task<IEnumerable<PostResponse>> Handle(GetPostsByUserIdRequest request, CancellationToken cancellationToken) =>
            repository.GetPostsByUserId(request.UserId, request, cancellationToken);
    }
}

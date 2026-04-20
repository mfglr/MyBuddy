using MediatR;

namespace PostQueryService.Application.UseCases.GetById
{
    internal class GetByIdHandler(
        IPostQueryRepository repository,
        GetByIdMapper mapper
    ) : IRequestHandler<GetByIdRequest, PostProjectionResponse>
    {
        public async Task<PostProjectionResponse> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            var post = 
                await repository.GetByIdQueryAsync(request.Id, cancellationToken) ??
                throw new PostNotFoundException();
            return mapper.Map(post);
        }
    }
}

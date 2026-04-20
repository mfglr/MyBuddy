using MediatR;

namespace PostQueryService.Application.UseCases.SearchPosts
{
    internal class SearchPostsHandler(
        IPostQueryRepository repository,
        SearchPostsMapper mapper
    ) : IRequestHandler<SearchPostsRequest, IEnumerable<PostProjectionResponse>>
    {
        public async Task<IEnumerable<PostProjectionResponse>> Handle(SearchPostsRequest request, CancellationToken cancellationToken)
        {
            var posts = await repository.SearchAsync(request.Key, request.Score, request.Id, request.PageSize, cancellationToken);
            return posts.Select(x => mapper.Map(x.post, x.score));
        }
    }
}

using MediatR;

namespace PostQueryService.Application.UseCases.SearchPosts
{
    public record SearchPostsRequest(string Key, double? Score, string? Id, int PageSize = 20)
        : IRequest<IEnumerable<PostProjectionResponse>>;
}

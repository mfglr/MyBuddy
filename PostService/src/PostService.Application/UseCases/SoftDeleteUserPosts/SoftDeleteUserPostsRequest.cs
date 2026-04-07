using MediatR;

namespace PostService.Application.UseCases.SoftDeleteUserPosts
{
    public record SoftDeleteUserPostsRequest(Guid UserId) : IRequest;
}

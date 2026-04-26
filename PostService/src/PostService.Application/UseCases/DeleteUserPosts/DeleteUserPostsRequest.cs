using MediatR;

namespace PostService.Application.UseCases.SoftDeleteUserPosts
{
    public record DeleteUserPostsRequest(Guid UserId) : IRequest;
}

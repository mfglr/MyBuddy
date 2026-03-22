using MediatR;

namespace PostService.Application.UseCases.DeletePosts
{
    public record DeletePostsRequest(Guid UserId) : IRequest;
}

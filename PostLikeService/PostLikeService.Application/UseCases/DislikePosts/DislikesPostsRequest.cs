using MediatR;

namespace PostLikeService.Application.UseCases.DislikePosts
{
    public record DislikesPostsRequest(Guid PostId) : IRequest;
}

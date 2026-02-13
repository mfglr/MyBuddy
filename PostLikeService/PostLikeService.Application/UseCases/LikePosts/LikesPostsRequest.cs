using MediatR;

namespace PostLikeService.Application.UseCases.LikePosts
{
    public record LikesPostsRequest(Guid PostId) : IRequest;
}

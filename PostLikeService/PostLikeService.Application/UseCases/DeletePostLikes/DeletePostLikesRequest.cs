using MediatR;

namespace PostLikeService.Application.UseCases.DeletePostLikes
{
    public record DeletePostLikesRequest(Guid PostId) : IRequest;
}

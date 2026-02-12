using MediatR;

namespace PostLikeService.Application.UseCases.LikePost
{
    public record LikePostRequest(Guid PostId) : IRequest;
}

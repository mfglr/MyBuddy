using MediatR;

namespace PostLikeService.Application.UseCases.DislikePost
{
    public record DislikePostRequest(Guid PostId) : IRequest;
}

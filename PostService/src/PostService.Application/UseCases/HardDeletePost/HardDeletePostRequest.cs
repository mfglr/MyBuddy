using MediatR;

namespace PostService.Application.UseCases.HardDeletePost
{
    public record HardDeletePostRequest(Guid Id) : IRequest;
}

using CommentLikeQueryService.Domain;
using MediatR;

namespace CommentLikeQueryService.Application.UseCases.UpdateUser
{
    public record UpdateUserRequest(User User) : IRequest;
}

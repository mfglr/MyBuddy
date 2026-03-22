using CommentQueryService.Domain;
using MediatR;

namespace CommentQueryService.Application.UseCases.UpdateUser
{
    public record UpdateUserRequest(User User) : IRequest;
}

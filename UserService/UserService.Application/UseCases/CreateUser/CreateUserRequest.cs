using MediatR;

namespace UserService.Application.UseCases.CreateUser
{
    public record CreateUserRequest(Guid Id) : IRequest;
}

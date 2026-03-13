using MediatR;

namespace AuthServer.Application.UseCases.CreateAccount
{
    public record CreateAccountRequest(string Email, string Password) : IRequest<CreateAccountResponse>;
}

using MediatR;

namespace AuthServer.Application.UseCases.UpdateUserName
{
    public record UpdateUserNameRequest(string UserName) : IRequest;
}

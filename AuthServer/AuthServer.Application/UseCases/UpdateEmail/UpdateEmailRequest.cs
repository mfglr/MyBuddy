using MediatR;

namespace AuthServer.Application.UseCases.UpdateEmail
{
    public record UpdateEmailRequest(string Email) : IRequest;
}

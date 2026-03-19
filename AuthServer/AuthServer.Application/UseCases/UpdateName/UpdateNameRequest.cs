using MediatR;

namespace AuthServer.Application.UseCases.UpdateName
{
    public record UpdateNameRequest(string Name) : IRequest;
}

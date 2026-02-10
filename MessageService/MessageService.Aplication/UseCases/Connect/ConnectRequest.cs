using MediatR;

namespace MessageService.Aplication.UseCases.Connect
{
    public record ConnectRequest(string ConnectionId) : IRequest;
}

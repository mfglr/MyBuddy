using MediatR;

namespace RealtimeService.Application.UseCases.Connect
{
    public record ConnectRequest(string ConnectionId) : IRequest;
}

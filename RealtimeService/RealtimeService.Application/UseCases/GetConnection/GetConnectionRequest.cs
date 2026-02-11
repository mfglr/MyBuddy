using MediatR;

namespace RealtimeService.Application.UseCases.GetConnection
{
    public record GetConnectionRequest(Guid Id) : IRequest<GetConnectionResponse>;
}

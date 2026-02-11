using AutoMapper;
using MediatR;
using RealtimeService.Domain;

namespace RealtimeService.Application.UseCases.GetConnection
{
    internal class GetConnectionHandler(IMapper mapper, IConnectionRepository connectionRepository) : IRequestHandler<GetConnectionRequest, GetConnectionResponse>
    {
        public async Task<GetConnectionResponse> Handle(GetConnectionRequest request, CancellationToken cancellationToken)
        {
            var connection = await connectionRepository.GetByIdAsync(request.Id, cancellationToken) ?? new Connection(request.Id);
            return mapper.Map<Connection,GetConnectionResponse>(connection);
        }
    }
}

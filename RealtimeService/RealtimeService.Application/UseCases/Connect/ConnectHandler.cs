using MediatR;
using RealtimeService.Domain;

namespace RealtimeService.Application.UseCases.Connect
{
    internal class ConnectHandler(IIdentityService identityService, IConnectionRepository connectionRepository) : IRequestHandler<ConnectRequest>
    {
        public async Task Handle(ConnectRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var connection = await connectionRepository.GetByIdAsync(userId, cancellationToken);
            if(connection == null)
            {
                connection = new Connection(userId);
                connection.Connect(request.ConnectionId);
                await connectionRepository.CreateAsync(connection, cancellationToken);
            }
            else
            {
                connection.Connect(request.ConnectionId);
                await connectionRepository.UpdateAsync(connection, cancellationToken);
            }

        }
    }
}

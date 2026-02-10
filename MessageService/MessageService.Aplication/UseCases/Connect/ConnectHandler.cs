using MediatR;
using MessageService.Domain.ConnectionAggregate;

namespace MessageService.Aplication.UseCases.Connect
{
    internal class ConnectHandler(IConnectionRepository connectionRepository, IIdentityService identityService) : IRequestHandler<ConnectRequest>
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
                return;
            }
            connection.Connect(request.ConnectionId);
            await connectionRepository.UpdateAsync(connection, cancellationToken);
        }
    }
}

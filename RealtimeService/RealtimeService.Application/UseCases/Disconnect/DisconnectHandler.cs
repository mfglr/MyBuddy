using MediatR;
using RealtimeService.Domain;

namespace RealtimeService.Application.UseCases.Disconnect
{
    internal class DisconnectHandler(IIdentityService identityService, IConnectionRepository connectionRepository) : IRequestHandler<DisconnectRequest>
    {
        public async Task Handle(DisconnectRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var connection = await connectionRepository.GetByIdAsync(userId, cancellationToken);
            if (connection == null)
            {
                connection = new Connection(userId);
                connection.Disconnect();
                await connectionRepository.CreateAsync(connection, cancellationToken);
            }
            else
            {
                connection.Disconnect();
                await connectionRepository.UpdateAsync(connection, cancellationToken);
            }
        }
    }
}

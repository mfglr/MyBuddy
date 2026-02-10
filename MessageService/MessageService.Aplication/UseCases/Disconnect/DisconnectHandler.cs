using MediatR;
using MessageService.Domain.ConnectionAggregate;

namespace MessageService.Aplication.UseCases.Disconnect
{
    internal class DisconnectHandler(IConnectionRepository connectionRepository, IIdentityService identityService) : IRequestHandler<DisconnectRequest>
    {
        public async Task Handle(DisconnectRequest request, CancellationToken cancellationToken)
        {
            var userId = identityService.UserId;
            var connection = await connectionRepository.GetByIdAsync(userId, cancellationToken);
            if (connection == null) return;

            connection.Disconnect();
            await connectionRepository.UpdateAsync(connection, cancellationToken);
        }
    }
}

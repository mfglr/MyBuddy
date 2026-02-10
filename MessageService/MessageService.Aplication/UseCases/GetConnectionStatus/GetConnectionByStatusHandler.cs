using MediatR;
using MessageService.Domain.ConnectionAggregate;

namespace MessageService.Aplication.UseCases.GetConnectionStatus
{
    internal class GetConnectionByStatusHandler(IConnectionRepository connectionRepository) : IRequestHandler<GetConnectionStatusByIdRequest, GetConnectionStatusByIdResponse>
    {
        public async Task<GetConnectionStatusByIdResponse> Handle(GetConnectionStatusByIdRequest request, CancellationToken cancellationToken)
        {
            var connection = await connectionRepository.GetByIdAsync(request.Id, cancellationToken);
            return connection != null
                ? new(connection.ConenctionId != null, connection.LastConnectedAt)
                : new(false, null);
        }
    }
}

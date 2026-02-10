using MediatR;

namespace MessageService.Aplication.UseCases.GetConnectionStatus
{
    public record GetConnectionStatusByIdRequest(Guid Id) : IRequest<GetConnectionStatusByIdResponse>;
}

using MediatR;

namespace AuthServer.Application.UseCases.GetById
{
    public record GetByIdRequest(Guid Id) : IRequest<GetByIdReponse>;
}

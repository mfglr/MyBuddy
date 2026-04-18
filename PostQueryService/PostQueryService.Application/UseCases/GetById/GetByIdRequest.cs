using MediatR;

namespace PostQueryService.Application.UseCases.GetById
{
    public record GetByIdRequest(string Id) : IRequest<PostProjectionResponse>;
}

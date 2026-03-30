using MediatR;
using PostQueryService.Domain;

namespace PostQueryService.Application.UseCases.UpdatePost
{
    public record UpdatePostRequest(string Id, Post Post) : IRequest;
}

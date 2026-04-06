using MediatR;

namespace PostQueryService.Application.UseCases.UpdatePostUser
{
    public record UpdatePostUserRequest(
        Guid Id,
        DateTime? DeletedAt,
        int Version,
        string UserName,
        string? Name,
        Media.Models.Media? Media
    ) : IRequest;
}

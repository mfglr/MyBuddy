using MediatR;

namespace PostQueryService.Application.UseCases.UpsertUser
{
    public record UpsertUserRequest(
        Guid Id,
        DateTime? DeletedAt,
        int Version,
        string? Name,
        string UserName,
        Media.Models.Media? Media
    ) : IRequest;
}

namespace AuthServer.Application.UseCases.GetById
{
    public record GetByIdReponse(
        Guid Id,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        string? Name,
        string UserName,
        Media.Models.Media? Media
    );
}
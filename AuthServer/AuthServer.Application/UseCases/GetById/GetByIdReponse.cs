using Media.Models;

namespace AuthServer.Application.UseCases.GetById
{
    public record GetByIdReponse_Media(
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    );

    public record GetByIdReponse(
        Guid Id,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        string? Name,
        string UserName,
        GetByIdReponse_Media? Media
    );
}
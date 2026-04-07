using Media.Models;
using MediatR;

namespace MediaService.Application.UseCases.CreateMedia
{
    public record CreateMediaRequest_Media(
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    );

    public record CreateMediaRequest(
        Guid Id,
        IEnumerable<CreateMediaRequest_Media> Media
    ) : IRequest;
}

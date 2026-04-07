using Media.Models;
using MediatR;

namespace PostService.Application.UseCases.SetPostMedia
{
    public record SetPostMediaRequest(
        Guid Id,
        string BlobName,
        MediaProcessingContext Context
    ) : IRequest;
}

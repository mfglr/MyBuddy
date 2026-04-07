using Media.Models;
using MediatR;

namespace AuthServer.Application.UseCases.SetMedia
{
    public record SetMediaRequest(
        Guid Id,
        string BlobName,
        MediaProcessingContext Context
    ) : IRequest;
}

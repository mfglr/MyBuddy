using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetTranscodedBlobName
{
    public record SetTranscodedBlobNameRequest(MediaListId Id, string BlobName, string TranscodedBlobName) : IRequest;
}

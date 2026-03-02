using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.SetTranscodedBlobName
{
    public record SetTranscodedBlobNameRequest(string ContainerName, string BlobName, string TranscodedBlobName) : IRequest;
}

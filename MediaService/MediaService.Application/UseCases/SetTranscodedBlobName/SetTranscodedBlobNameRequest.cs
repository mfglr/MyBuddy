using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.SetTranscodedBlobName
{
    public record SetTranscodedBlobNameRequest(MediaId Id, string TranscodedBlobName) : IRequest;
}

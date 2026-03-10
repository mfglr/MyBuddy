using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.AddTranscoding
{
    public record AddTrascodingRequest(
        string ContainerName,
        string BlobName,
        Transcoding Transcoding
    ) : IRequest;
}

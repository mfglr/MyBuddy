using Media.Models;
using MediatR;

namespace MediaService.Application.UseCases.AddTranscoding
{
    public record AddTrascodingRequest(
        string ContainerName,
        string BlobName,
        Transcoding Transcoding
    ) : IRequest;
}

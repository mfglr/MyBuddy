using Media.Models;
using MediatR;

namespace MediaService.Application.UseCases.SetModerationResult
{
    public record SetModerationResultRequest(
        string ContainerName,
        string BlobName,
        ModerationResult ModerationResult
    ) : IRequest;
}

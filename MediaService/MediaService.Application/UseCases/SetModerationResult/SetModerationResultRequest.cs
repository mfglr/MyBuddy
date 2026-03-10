using MediaService.Domain;
using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.SetModerationResult
{
    public record SetModerationResultRequest(
        string ContainerName,
        string BlobName,
        ModerationResult ModerationResult
    ) : IRequest;
}

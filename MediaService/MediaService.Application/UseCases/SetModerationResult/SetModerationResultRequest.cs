using MediaService.Domain;
using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.SetModerationResult
{
    public record SetModerationResultRequest(
        MediaListId Id,
        string BlobName,
        ModerationResult? ModerationResult
    ) : IRequest;
}

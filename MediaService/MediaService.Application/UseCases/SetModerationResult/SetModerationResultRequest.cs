using MediaService.Domain;
using MediatR;
using Shared.Events.SharedObjects;

namespace MediaService.Application.UseCases.SetModerationResult
{
    public record SetModerationResultRequest(
        MediaId Id,
        ModerationResult? ModerationResult
    ) : IRequest;
}

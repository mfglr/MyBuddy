using Shared.Events.SharedObjects;

namespace UserService.Application.UseCases.SetMediaModerationResult
{
    public record SetMediaModerationResultRequest(Guid Id, string BlobName, ModerationResult ModerationResult) : MediatR.IRequest;
}

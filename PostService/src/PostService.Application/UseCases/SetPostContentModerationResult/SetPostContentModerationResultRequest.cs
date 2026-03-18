using Media.Models;
using MediatR;

namespace PostService.Application.UseCases.SetPostContentModerationResult
{
    public record SetPostContentModerationResultRequest(Guid Id, ModerationResult ModerationResult) : IRequest;
}

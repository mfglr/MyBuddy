using MediatR;
using Shared.Events.SharedObjects;

namespace CommentService.Application.UseCases.SetCommentContentModerationResult
{
    public record SetCommentContentModerationResultRequest(Guid Id, ModerationResult ModerationResult) : IRequest;
}

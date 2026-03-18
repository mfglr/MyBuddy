using Media.Models;
using MediatR;

namespace CommentService.Application.UseCases.SetCommentContentModerationResult
{
    public record SetCommentContentModerationResultRequest(Guid Id, ModerationResult ModerationResult) : IRequest;
}

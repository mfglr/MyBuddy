using Media.Models;
using MediatR;

namespace ContentModerator.Application.UseCases.ClassifyText
{
    public record ClassifyTextRequest(string Text) : IRequest<ModerationResult>;
}

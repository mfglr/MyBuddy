using MediatR;
using Shared.Objects;

namespace ContentModerator.Application.UseCases.ClassifyText
{
    public record ClassifyTextRequest(string Text) : IRequest<ModerationResult>;
}

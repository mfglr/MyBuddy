using MediatR;
using Shared.Events.SharedObjects;

namespace ContentModerator.Application.UseCases.ClassifyText
{
    public record ClassifyTextRequest(string Text) : IRequest<ModerationResult>;
}

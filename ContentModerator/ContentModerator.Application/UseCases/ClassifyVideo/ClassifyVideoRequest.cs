using MediatR;
using Microsoft.AspNetCore.Http;
using Shared.Objects;

namespace ContentModerator.Application.UseCases.ClassifyVideo
{
    public record ClassifyVideoRequest(IFormFile File) : IRequest<ModerationResult>;
}

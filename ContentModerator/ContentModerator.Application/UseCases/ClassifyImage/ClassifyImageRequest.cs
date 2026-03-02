using MediatR;
using Shared.Events.SharedObjects;

namespace ContentModerator.Application.UseCases.ClassifyImage
{
    public record ClassifyImageRequest(string ContainerName, string BlobName) : IRequest<ModerationResult>;
}

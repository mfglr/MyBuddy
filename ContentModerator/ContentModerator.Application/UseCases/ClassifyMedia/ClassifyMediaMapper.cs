using Media.Models;
using Shared.Events.MediaService;

namespace ContentModerator.Application.UseCases.ClassifyMedia
{
    internal class ClassifyMediaMapper
    {
        public MediaClassifiedEvent Map(ClassifyMediaRequest request, ModerationResult moderationResult) =>
            new(
                request.ContainerName,
                request.BlobName,
                moderationResult
            );
    }
}

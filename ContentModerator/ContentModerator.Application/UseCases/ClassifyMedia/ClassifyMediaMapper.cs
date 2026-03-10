using Shared.Events.MediaService;
using Shared.Events.SharedObjects;

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

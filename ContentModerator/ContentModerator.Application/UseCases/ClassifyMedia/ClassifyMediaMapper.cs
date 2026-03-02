using Shared.Events.MediaService;
using Shared.Events.SharedObjects;

namespace ContentModerator.Application.UseCases.ClassifyMedia
{
    internal class ClassifyMediaMapper
    {
        public MediaClassificationValidatedEvent MapValidatedEvent(ClassifyMediaRequest request, ModerationResult? moderationResult) =>
            new(
                request.ContainerName,
                request.BlobName,
                request.Type,
                moderationResult,
                request.Instruction
            );

        public MediaClassificationInvalidatedEvent MapInvalidatedEvent(ClassifyMediaRequest request, ModerationResult moderationResult) =>
            new(
                request.ContainerName,
                request.BlobName,
                moderationResult
            );
    }
}

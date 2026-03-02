using MediatR;
using Shared.Events.SharedObjects;

namespace ThumbnailGenerator.Application.UseCases.GenerateThumbnail
{
    public record GenerateThumbnailRequest(string ContainerName, string BlobName, double Resulation, bool IsSquare) : IRequest<Thumbnail>;
}

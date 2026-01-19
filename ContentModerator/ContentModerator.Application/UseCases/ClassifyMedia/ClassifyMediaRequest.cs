using MediatR;
using Shared.Objects;

namespace ContentModerator.Application.UseCases.ClassifyMedia
{
    public record ClassifyMediaRequest(Guid Id, string ContainerName, string BlobName, MediaType Type) : IRequest;
}

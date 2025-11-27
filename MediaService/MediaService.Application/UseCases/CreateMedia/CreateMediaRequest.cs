using Shared.Objects;

namespace MediaService.Application.UseCases.CreateMedia
{
    public record CreateMediadRequest_Media(string ContainerName, string BlobName, MediaType Type);
    public record CreateMediaRequest(Guid OwnerId, IEnumerable<CreateMediadRequest_Media> Media);
}

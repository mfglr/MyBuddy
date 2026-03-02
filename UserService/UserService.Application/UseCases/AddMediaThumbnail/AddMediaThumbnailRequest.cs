using Shared.Events.SharedObjects;

namespace UserService.Application.UseCases.AddMediaThumbnail
{
    public record AddMediaThumbnailRequest(Guid Id, string BlobName, Thumbnail Thumbnail) : MediatR.IRequest;
}

using PostQueryService.Domain;
using PostQueryService.Domain.PostProjectionAggregate;

namespace PostQueryService.Application.UseCases.UpdatePostUser
{
    internal class UpdatePostUserMapper
    {
        public PostQueryMedia Map(UpdatePostUserRequest_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context.Type,
                media.Context.Metadata,
                media.Context.ModerationResult,
                media.Context.Thumbnails,
                media.Context.Transcodings
            );

        public PostProjectionUser Map(UpdatePostUserRequest request) =>
            new(
                request.Version,
                request.Name,
                request.UserName,
                request.Media != null ? Map(request.Media) : null
            );
    }
}

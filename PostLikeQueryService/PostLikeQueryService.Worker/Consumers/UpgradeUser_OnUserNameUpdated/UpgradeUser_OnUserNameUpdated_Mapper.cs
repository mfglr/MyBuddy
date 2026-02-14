using PostLikeQueryService.Application.UseCases.UpgradeUser;
using PostLikeQueryService.Domain.UserAggregate;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpgradeUser_OnUserNameUpdated
{
    internal class UpgradeUser_OnUserNameUpdated_Mapper
    {
        public UpgradeUserRequest Map(UserNameUpdatedEvent @event)
        {
            var media = @event.Media.FirstOrDefault(x => x.IsActive);
            return new(
                @event.Id,
                @event.Version,
                @event.IsDeleted,
                @event.Name,
                @event.UserName,
                media != null
                    ? new(
                        media.ContainerName,
                        media.BlobName,
                        new(
                            media.Metadata!.Width,
                            media.Metadata!.Height,
                            media.Metadata.Duration
                        ),
                        new(
                            media.ModerationResult!.Hate,
                            media.ModerationResult!.SelfHarm,
                            media.ModerationResult.Sexual,
                            media.ModerationResult.Violence
                        ),
                        media.Thumbnails.Select(
                            x => new Thumbnail(
                                x.BlobName,
                                x.Resolution,
                                x.IsSquare
                            )
                        )
                    )
                    : null
            );
        }

    }
}

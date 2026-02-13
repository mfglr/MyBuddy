using AutoMapper;
using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Application.UseCases.UpgradeUser
{
    internal class UpgradeUserMapper : Profile
    {
        public UpgradeUserMapper()
        {
            CreateMap<UpgradeUserRequest_Media, Media>();
        }
    }
}

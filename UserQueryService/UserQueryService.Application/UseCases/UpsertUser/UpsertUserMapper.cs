using AutoMapper;
using UserQueryService.Domain;

namespace UserQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserMapper : Profile
    {
        public UpsertUserMapper()
        {
            CreateMap<Shared.Events.Metadata, Metadata>();
            CreateMap<Shared.Events.ModerationResult, ModerationResult>();
            CreateMap<Shared.Events.Thumbnail, Thumbnail>();
            CreateMap<UpsertUserRequest_Media, Media>();
        }
    }
}

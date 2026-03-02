using AutoMapper;
using Shared.Events.SharedObjects;
using UserQueryService.Domain;

namespace UserQueryService.Application.UseCases.UpsertUser
{
    internal class UpsertUserMapper : Profile
    {
        public UpsertUserMapper()
        {
            //CreateMap<Shared.Events.SharedObjects.Metadata, Metadata>();
            //CreateMap<Shared.Events.SharedObjects.ModerationResult, ModerationResult>();
            //CreateMap<Shared.Events.SharedObjects.Thumbnail, Thumbnail>();
            //CreateMap<UpsertUserRequest_Media, Media>();
        }
    }
}

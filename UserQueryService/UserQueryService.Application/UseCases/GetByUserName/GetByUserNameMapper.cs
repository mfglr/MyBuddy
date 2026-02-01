using AutoMapper;
using UserQueryService.Domain;

namespace UserQueryService.Application.UseCases.GetByUserName
{
    internal class GetByUserNameMapper : Profile
    {
        public GetByUserNameMapper()
        {
            CreateMap<Metadata, Shared.Events.Metadata>();
            CreateMap<ModerationResult, Shared.Events.ModerationResult>();
            CreateMap<Thumbnail, Shared.Events.Thumbnail>();
            CreateMap<Media, GetByUserNameResponse_Media>();
            CreateMap<User, GetByUserNameResponse>();
        }
    }
}

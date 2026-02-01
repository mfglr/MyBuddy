using AutoMapper;
using UserService.Domain;

namespace UserService.Application.UseCases.GetUserById
{
    internal class GetUserByIdMapper : Profile
    {
        public GetUserByIdMapper()
        {
            CreateMap<ModerationResult, Shared.Events.ModerationResult>();
            CreateMap<Thumbnail, Shared.Events.Thumbnail>();
            CreateMap<Metadata, Shared.Events.Metadata>();
            CreateMap<Media, GetUserByIdResponse_Media>();
            CreateMap<User, GetUserByIdResponse>()
                .ForCtorParam("UserName", cfg => cfg.MapFrom(x => x.UserName.Value))
                .ForCtorParam("Name", cfg => cfg.MapFrom(x => x.Name != null ? x.Name.Value : null))
                .ForCtorParam("Gender", cfg => cfg.MapFrom(x => x.Gender.Value));
        }
    }
}

using AutoMapper;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateGender
{
    internal class UpdateGenderMapper : Profile
    {
        public UpdateGenderMapper()
        {
            CreateMap<Metadata, Shared.Events.Metadata>();
            CreateMap<Thumbnail, Shared.Events.Thumbnail>();
            CreateMap<ModerationResult, Shared.Events.ModerationResult>();
            CreateMap<Media, UserGenderUpdatedEvent_Media>();
            CreateMap<User, UserGenderUpdatedEvent>()
                .ForCtorParam("UserName", cfg => cfg.MapFrom(x => x.UserName.Value))
                .ForCtorParam("Name", cfg => cfg.MapFrom(x => x.Name != null ? x.Name.Value : null))
                .ForCtorParam("Gender", cfg => cfg.MapFrom(x => x.Gender.Value));
        }
    }
}

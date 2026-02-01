using AutoMapper;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.CreateUser
{
    internal class CreateUserMapper : Profile
    {
        public CreateUserMapper()
        {
            CreateMap<Metadata, Shared.Events.Metadata>();
            CreateMap<Thumbnail, Shared.Events.Thumbnail>();
            CreateMap<ModerationResult, Shared.Events.ModerationResult>();
            CreateMap<Media, UserCreatedEvent_Media>();
            CreateMap<User, UserCreatedEvent>()
                .ForCtorParam("UserName", cfg => cfg.MapFrom(x => x.UserName.Value))
                .ForCtorParam("Name", cfg => cfg.MapFrom(x => x.Name != null ? x.Name.Value : null))
                .ForCtorParam("Gender", cfg => cfg.MapFrom(x => x.Gender.Value));
        }
    }
}

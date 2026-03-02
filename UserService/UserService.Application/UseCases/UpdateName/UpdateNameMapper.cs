using AutoMapper;
using Shared.Events.SharedObjects;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateName
{
    internal class UpdateNameMapper : Profile
    {
        public UpdateNameMapper()
        {
            CreateMap<Media, NameUpdatedEvent_Media>();
            CreateMap<User, NameUpdatedEvent>()
                .ForCtorParam("UserName", cfg => cfg.MapFrom(x => x.UserName.Value))
                .ForCtorParam("Name", cfg => cfg.MapFrom(x => x.Name != null ? x.Name.Value : null))
                .ForCtorParam("Gender", cfg => cfg.MapFrom(x => x.Gender.Value));
        }
    }
}

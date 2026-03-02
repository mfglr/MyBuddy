using AutoMapper;
using Shared.Events.SharedObjects;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateUserName
{
    internal class UpdateUserNameMapper : Profile
    {
        public UpdateUserNameMapper()
        {
            CreateMap<Media, UserNameUpdatedEvent_Media>();
            CreateMap<User, UserNameUpdatedEvent>()
                .ForCtorParam("UserName", cfg => cfg.MapFrom(x => x.UserName.Value))
                .ForCtorParam("Name", cfg => cfg.MapFrom(x => x.Name != null ? x.Name.Value : null))
                .ForCtorParam("Gender", cfg => cfg.MapFrom(x => x.Gender.Value));
        }
    }
}

using AutoMapper;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.CreateUser
{
    public class CreateUserMapper : Profile
    {
        public CreateUserMapper()
        {
            CreateMap<User, UserCreatedEvent>()
                .ForMember(x => x.Username, cfg => cfg.MapFrom(x => x.Username.Value))
                .ForMember(x => x.Name, cfg => cfg.MapFrom(x => x.Name.Value))
                .ForMember(x => x.Gender, cfg => cfg.MapFrom(x => x.Gender.Value));
        }
    }
}

using AutoMapper;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.UpdateName
{
    internal class UpdateNameMapper : Profile
    {
        public UpdateNameMapper()
        {
            CreateMap<User, NameUpdatedEvent>();
        }
    }
}

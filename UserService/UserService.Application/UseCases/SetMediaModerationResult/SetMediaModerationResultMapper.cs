using AutoMapper;
using Shared.Events.SharedObjects;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.SetMediaModerationResult
{
    internal class SetMediaModerationResultMapper : Profile
    {
        public SetMediaModerationResultMapper()
        {
            CreateMap<Media, UserMediaPreproccessingCompletedEvent_Media>();
            CreateMap<User, UserMediaPreprocessingCompletedEvent>()
                .ForCtorParam("UserName", cfg => cfg.MapFrom(x => x.UserName.Value))
                .ForCtorParam("Name", cfg => cfg.MapFrom(x => x.Name != null ? x.Name.Value : null))
                .ForCtorParam("Gender", cfg => cfg.MapFrom(x => x.Gender.Value));
        }
    }
}

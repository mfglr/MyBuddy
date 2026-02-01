using AutoMapper;
using Shared.Events.UserService;
using UserService.Domain;

namespace UserService.Application.UseCases.AddMediaThumbnail
{
    internal class AddMediaThumbnailMapper : Profile
    {
        public AddMediaThumbnailMapper()
        {
            CreateMap<Shared.Events.Thumbnail, Thumbnail>();

            CreateMap<Metadata, Shared.Events.Metadata>();
            CreateMap<Thumbnail, Shared.Events.Thumbnail>();
            CreateMap<ModerationResult, Shared.Events.ModerationResult>();
            CreateMap<Media, UserMediaPreproccessingCompletedEvent_Media>();
            CreateMap<User, UserMediaPreprocessingCompletedEvent>()
                .ForCtorParam("UserName", cfg => cfg.MapFrom(x => x.UserName.Value))
                .ForCtorParam("Name", cfg => cfg.MapFrom(x => x.Name != null ? x.Name.Value : null))
                .ForCtorParam("Gender", cfg => cfg.MapFrom(x => x.Gender.Value));
        }
    }
}

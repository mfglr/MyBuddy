using AutoMapper;
using PostService.Application.UseCases.SetPostContentModerationResult;
using PostService.Application.UseCases.SetPostMedia;
using Shared.Events.Media;
using Shared.Events.PostService;

namespace PostService.Workers.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SetPostContentModerationResultResponse_Content, PostContentModerationResultSetEvent_Content>();
            CreateMap<SetPostContentModerationResultResponse_Media, PostContentModerationResultSetEvent_Media>();
            CreateMap<SetPostContentModerationResultResponse, PostContentModerationResultSetEvent>();

            CreateMap<MediaPreprocessingCompletedEvent, SetPostMediaRequest>();
            CreateMap<SetPostMediaResponse_Content, PostMediaSetEvent_Content>();
            CreateMap<SetPostMediaResponse_Media, PostMediaSetEvent_Media>();
            CreateMap<SetPostMediaResponse, PostMediaSetEvent>();
        }
    }
}

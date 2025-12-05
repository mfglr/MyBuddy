using AutoMapper;
using QueryService.Application.UseCases.PostUseCases.UpdatePost;
using Shared.Events.PostService;

namespace QueryService.Workers.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PostMediaDeletedEvent_Content, UpdatePostRequest_Content>();
            CreateMap<PostMediaDeletedEvent_Media, UpdatePostRequest_Media>();
            CreateMap<PostMediaDeletedEvent, UpdatePostRequest>();

            CreateMap<PostContentModerationResultSetEvent_Content, UpdatePostRequest_Content>();
            CreateMap<PostContentModerationResultSetEvent_Media, UpdatePostRequest_Media>();
            CreateMap<PostContentModerationResultSetEvent, UpdatePostRequest>();

            CreateMap<PostMediaSetEvent_Content, UpdatePostRequest_Content>();
            CreateMap<PostMediaSetEvent_Media, UpdatePostRequest_Media>();
            CreateMap<PostMediaSetEvent, UpdatePostRequest>();
        }
    }
}

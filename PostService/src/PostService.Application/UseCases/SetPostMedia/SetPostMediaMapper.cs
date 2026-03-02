using AutoMapper;
using PostService.Domain;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.SetPostMedia
{
    internal class SetPostMediaMapper : Profile
    {
        public SetPostMediaMapper()
        {
            CreateMap<Content, PostContentModerationResultSetEvent_Content>();
            CreateMap<Media, PostContentModerationResultSetEvent_Media>();
            CreateMap<Post, PostContentModerationResultSetEvent>();
        }
    }
}

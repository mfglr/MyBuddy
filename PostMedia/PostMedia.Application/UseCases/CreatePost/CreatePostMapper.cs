using AutoMapper;
using PostMedia.Domain;
using Shared.Events.PostMediaService;

namespace PostMedia.Application.UseCases.CreatePost
{
    internal class CreatePostMapper : Profile
    {
        public CreatePostMapper()
        {
            CreateMap<CreatePostRequest_Media, Media>();

            CreateMap<Media, PostMediaCreatedEvent>();
            CreateMap<Post, PostMediaCreatedEvent>();
        }
    }
}

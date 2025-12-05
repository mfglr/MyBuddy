using AutoMapper;
using PostService.Domain;

namespace PostService.Application.UseCases.SetPostMedia
{
    internal class SetPostMediaMapper : Profile
    {
        public SetPostMediaMapper()
        {
            CreateMap<Content, SetPostMediaResponse_Content>();
            CreateMap<Media, SetPostMediaResponse_Media>();
            CreateMap<Post, SetPostMediaResponse>();
        }
    }
}

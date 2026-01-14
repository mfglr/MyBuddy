using AutoMapper;
using PostService.Domain;

namespace PostService.Application.UseCases.RestorePost
{
    internal class RestorePostMapper : Profile
    {
        public RestorePostMapper()
        {
            CreateMap<Content, RestorePostResponse_Content>();
            CreateMap<Post, RestorePostResponse>();
        }
    }
}

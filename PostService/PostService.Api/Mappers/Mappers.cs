using AutoMapper;
using PostService.Application.UseCases.CreatePost;
using PostService.Application.UseCases.CreatePostMedia;
using PostService.Application.UseCases.DeletePost;
using PostService.Application.UseCases.DeletePostMedia;
using PostService.Application.UseCases.RestorePost;
using PostService.Domain;
using Shared.Events.PostService;

namespace PostService.Api.Mappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Content, CreatePostResponse_Content>();
            CreateMap<Post, CreatePostResponse>();

            CreateMap<CreatePostResponse_Content, PostCreatedEvent_Content>();
            CreateMap<CreatePostResponse, PostCreatedEvent>();

            CreateMap<DeletePostMediaResponse_Content, PostMediaDeletedEvent_Content>();
            CreateMap<DeletePostMediaResponse, PostMediaDeletedEvent>();

            CreateMap<CreatePostMediaResponse, PostMediaCreatedEvent>();

            CreateMap<DeletePostResponse_Content, PostDeletedEvent_Content>();
            CreateMap<DeletePostResponse, PostDeletedEvent>();

            CreateMap<RestorePostResponse_Content, PostRestoredEvent_Content>();
            CreateMap<RestorePostResponse, PostRestoredEvent>();
        }
    }
}

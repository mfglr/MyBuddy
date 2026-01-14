using AutoMapper;
using QueryService.Application.UseCases.PostUseCases.UpdatePost;
using Shared.Events.PostService;
using Shared.Objects;

namespace QueryService.Workers.Consumers.PostDomain.RestorePost
{
    internal class RestorePostMapper : Profile
    {
        public RestorePostMapper()
        {
            CreateMap<PostRestoredEvent_Content, UpdatePostRequest_Content>();
            CreateMap<Media, UpdatePostRequest_Media>();
            CreateMap<PostRestoredEvent, UpdatePostRequest>();
        }
    }
}

using AutoMapper;
using QueryService.Application.UseCases.PostUseCases.UpdatePost;
using Shared.Events.PostService;
using Shared.Objects;

namespace QueryService.Workers.Consumers.PostDomain.SetPostContentModerationResult
{
    internal class SetPostContentModerationResultMapper : Profile
    {
        public SetPostContentModerationResultMapper()
        {
            CreateMap<PostContentModerationResultSetEvent_Content, UpdatePostRequest_Content>();
            CreateMap<Media, UpdatePostRequest_Media>();
            CreateMap<PostContentModerationResultSetEvent, UpdatePostRequest>();
        }
    }
}

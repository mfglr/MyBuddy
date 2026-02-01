using AutoMapper;
using MassTransit;
using MediatR;
using PostQueryService.Application.UseCases.UpsertPost;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.PostDomain
{
    internal class UpsertPost_OnPostContentModerationResultSet_Mapper : Profile
    {
        public UpsertPost_OnPostContentModerationResultSet_Mapper()
        {
            CreateMap<PostContentModerationResultSetEvent_Content, UpsertPostRequest_Content>();
            CreateMap<PostContentModerationResultSetEvent_Media, UpsertPostRequest_Media>();
            CreateMap<PostContentModerationResultSetEvent, UpsertPostRequest>();
        }
    }

    internal class UpsertPost_OnPostContentModerationResultSet_PostQueryService(ISender sender, IMapper mapper) : IConsumer<PostContentModerationResultSetEvent>
    {
        public Task Consume(ConsumeContext<PostContentModerationResultSetEvent> context)
        {
            var request = mapper.Map<PostContentModerationResultSetEvent, UpsertPostRequest>(context.Message);
            return sender.Send(request, context.CancellationToken);
        }
    }
}

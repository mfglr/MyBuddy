using AutoMapper;
using MassTransit;
using MediatR;
using PostQueryService.Application.UseCases.UpsertPost;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.PostDomain
{
    internal class UpsertPost_OnPostDeleted_Mapper : Profile
    {
        public UpsertPost_OnPostDeleted_Mapper()
        {
            CreateMap<PostDeletedEvent_Content, UpsertPostRequest_Content>();
            CreateMap<PostDeletedEvent_Media, UpsertPostRequest_Media>();
            CreateMap<PostDeletedEvent, UpsertPostRequest>();
        }
    }

    internal class UpsertPost_OnPostDeleted_PostQueryService(ISender sender, IMapper mapper) : IConsumer<PostDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostDeletedEvent> context)
        {
            var request = mapper.Map<PostDeletedEvent, UpsertPostRequest>(context.Message);
            return sender.Send(request, context.CancellationToken);
        }
    }
}

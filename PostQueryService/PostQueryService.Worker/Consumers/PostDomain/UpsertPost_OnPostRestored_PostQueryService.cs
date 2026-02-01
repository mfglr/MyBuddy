using AutoMapper;
using MassTransit;
using MediatR;
using PostQueryService.Application.UseCases.UpsertPost;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.PostDomain
{
    internal class UpsertPost_OnPostRestore_Mapper : Profile
    {
        public UpsertPost_OnPostRestore_Mapper()
        {
            CreateMap<PostRestoredEvent_Content, UpsertPostRequest_Content>();
            CreateMap<PostRestoredEvent_Media, UpsertPostRequest_Media>();
            CreateMap<PostRestoredEvent, UpsertPostRequest>();
        }
    }

    internal class UpsertPost_OnPostRestored_PostQueryService(ISender sender, IMapper mapper) : IConsumer<PostRestoredEvent>
    {
        public Task Consume(ConsumeContext<PostRestoredEvent> context)
        {
            var request = mapper.Map<PostRestoredEvent, UpsertPostRequest>(context.Message);
            return sender.Send(request, context.CancellationToken);
        }
    }
}

using AutoMapper;
using MassTransit;
using MediatR;
using PostQueryService.Application.UseCases.UpsertPost;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.PostDomain
{

    internal class UpsertPost_OnPostPrepreccingCompleted_Mapper : Profile
    {
        public UpsertPost_OnPostPrepreccingCompleted_Mapper()
        {
            CreateMap<PostPreproccessingCompletedEvent_Content, UpsertPostRequest_Content>();
            CreateMap<PostPreproccessingCompletedEvent_Media, UpsertPostRequest_Media>();
            CreateMap<PostPreprocessingCompletedEvent, UpsertPostRequest>();
        }
    }

    internal class UpsertPost_OnPostProprecessingCompleted_PostQueryService(ISender sender,IMapper mapper) : IConsumer<PostPreprocessingCompletedEvent>
    {
        public Task Consume(ConsumeContext<PostPreprocessingCompletedEvent> context)
        {
            var request = mapper.Map<PostPreprocessingCompletedEvent, UpsertPostRequest>(context.Message);
            return sender.Send(request, context.CancellationToken);
        }
    }
}

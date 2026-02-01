using AutoMapper;
using MassTransit;
using MediatR;
using PostService.Application.UseCases.SetPostMedia;
using Shared.Events.PostMediaService;

namespace PostService.Workers.Consumers
{
    internal class SetPostMedia_OnPostMediaPreproccessingCompleted_Mapper : Profile
    {
        public SetPostMedia_OnPostMediaPreproccessingCompleted_Mapper()
        {
            CreateMap<PostMediaPreproccessingCompletedEvent_Media, SetPostMediaRequest_Media>();
            CreateMap<PostMediaPreprocessingCompletedEvent, SetPostMediaRequest>();
        }

    }

    internal class SetPostMedia_OnPostMediaPreproccessingCompleted_PostService(ISender sender, IMapper mapper) : IConsumer<PostMediaPreprocessingCompletedEvent>
    {
        public Task Consume(ConsumeContext<PostMediaPreprocessingCompletedEvent> context) =>
            sender
                .Send(
                    mapper.Map<PostMediaPreprocessingCompletedEvent, SetPostMediaRequest>(context.Message),
                    context.CancellationToken
                );
    }
}

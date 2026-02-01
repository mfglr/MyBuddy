using AutoMapper;
using MassTransit;
using MediatR;
using PostQueryService.Application.UseCases.UpsertUser;
using Shared.Events.UserService;

namespace PostQueryService.Worker.Consumers.UserDomain
{
    internal class UpserUser_OnUserMediaPreproccessingCompleted_Mapper : Profile
    {
        public UpserUser_OnUserMediaPreproccessingCompleted_Mapper()
        {
            CreateMap<UserMediaPreproccessingCompletedEvent_Media, UpsertUserRequest_Media>();
            CreateMap<UserMediaPreprocessingCompletedEvent, UpsertUserRequest>();
        }
    }

    internal class UpsertUser_OnUserMediaPreprocessingCompleted_PostQueryService(ISender sender, IMapper mapper) : IConsumer<UserMediaPreprocessingCompletedEvent>
    {
        public Task Consume(ConsumeContext<UserMediaPreprocessingCompletedEvent> context)
        {
            var request = mapper.Map<UserMediaPreprocessingCompletedEvent, UpsertUserRequest>(context.Message);
            return sender.Send(request,context.CancellationToken);
        }
    }
}

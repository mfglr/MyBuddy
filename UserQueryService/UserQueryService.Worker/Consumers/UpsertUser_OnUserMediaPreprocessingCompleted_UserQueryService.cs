using AutoMapper;
using MassTransit;
using MediatR;
using Shared.Events.UserService;
using UserQueryService.Application.UseCases.UpsertUser;

namespace UserQueryService.Worker.Consumers
{
    internal class UpsertUser_OnUserMediaPreproccessingCompleted_Mapper : Profile
    {
        public UpsertUser_OnUserMediaPreproccessingCompleted_Mapper()
        {
            CreateMap<UserMediaPreproccessingCompletedEvent_Media, UpsertUserRequest_Media>();
            CreateMap<UserMediaSetEvent, UpsertUserRequest>();
        }
    }

    internal class UpsertUser_OnUserMediaPreprocessingCompleted_UserQueryService(ISender sender, IMapper mapper) : IConsumer<UserMediaSetEvent>
    {
        public Task Consume(ConsumeContext<UserMediaSetEvent> context) =>
            sender
                .Send(
                    mapper.Map<UserMediaSetEvent, UpsertUserRequest>(context.Message),
                    context.CancellationToken
                );
    }
}

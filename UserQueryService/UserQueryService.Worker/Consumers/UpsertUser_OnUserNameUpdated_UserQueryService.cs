using AutoMapper;
using MassTransit;
using MediatR;
using Shared.Events.UserService;
using UserQueryService.Application.UseCases.UpsertUser;

namespace UserQueryService.Worker.Consumers
{
    internal class UpsertUser_OnUserNameUpdated_Mapper : Profile
    {
        public UpsertUser_OnUserNameUpdated_Mapper()
        {
            CreateMap<UserNameUpdatedEvent_Media, UpsertUserRequest_Media>();
            CreateMap<UserNameUpdatedEvent, UpsertUserRequest>();
        }
    }

    internal class UpsertUser_OnUserNameUpdated_UserQueryService(ISender sender, IMapper mapper) : IConsumer<UserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<UserNameUpdatedEvent> context) =>
            sender
                .Send(
                    mapper.Map<UserNameUpdatedEvent, UpsertUserRequest>(context.Message),
                    context.CancellationToken
                );
    }
}

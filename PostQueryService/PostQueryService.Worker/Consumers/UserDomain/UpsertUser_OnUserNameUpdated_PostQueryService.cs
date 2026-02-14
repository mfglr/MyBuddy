using AutoMapper;
using MassTransit;
using MediatR;
using PostQueryService.Application.UseCases.UpsertUser;
using Shared.Events.UserService;

namespace PostQueryService.Worker.Consumers.UserDomain
{
    internal class UpsertUser_OnUserNameUpdated_Mapper : Profile
    {
        public UpsertUser_OnUserNameUpdated_Mapper()
        {
            CreateMap<UserNameUpdatedEvent_Media, UpsertUserRequest_Media>();
            CreateMap<UserNameUpdatedEvent, UpsertUserRequest>();
        }
    }

    internal class UpsertUser_OnUserNameUpdated_PostQueryService(ISender sender, IMapper mapper) : IConsumer<UserNameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<UserNameUpdatedEvent> context)
        {
            var request = mapper.Map<UserNameUpdatedEvent, UpsertUserRequest>(context.Message);
            return sender.Send(request, context.CancellationToken);
        }
    }
}

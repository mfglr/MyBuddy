using AutoMapper;
using MassTransit;
using MediatR;
using PostQueryService.Application.UseCases.UpsertUser;
using Shared.Events.UserService;

namespace PostQueryService.Worker.Consumers.UserDomain
{
    internal class UpsertUser_OnUserCreated_Mapper : Profile
    {
        public UpsertUser_OnUserCreated_Mapper()
        {
            CreateMap<UserCreatedEvent_Media, UpsertUserRequest_Media>();
            CreateMap<UserCreatedEvent, UpsertUserRequest>();
        }
    }

    internal class UpsertUser_OnUserCreated_PostQueryService(ISender sender, IMapper mapper) : IConsumer<UserCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            var request = mapper.Map<UserCreatedEvent, UpsertUserRequest>(context.Message);
            return sender.Send(request, context.CancellationToken);
        }
    }
}

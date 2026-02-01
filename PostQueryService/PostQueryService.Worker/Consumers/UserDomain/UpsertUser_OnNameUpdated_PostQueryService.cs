using AutoMapper;
using MassTransit;
using MediatR;
using PostQueryService.Application.UseCases.UpsertUser;
using Shared.Events.UserService;

namespace PostQueryService.Worker.Consumers.UserDomain
{
    internal class UpsertUser_OnNameUpdated_Mapper : Profile
    {
        public UpsertUser_OnNameUpdated_Mapper()
        {
            CreateMap<NameUpdatedEvent_Media, UpsertUserRequest_Media>();
            CreateMap<NameUpdatedEvent, UpsertUserRequest>();
        }
    }

    internal class UpsertUser_OnNameUpdated_PostQueryService(ISender sender, IMapper mapper) : IConsumer<NameUpdatedEvent>
    {
        public Task Consume(ConsumeContext<NameUpdatedEvent> context)
        {
            var request = mapper.Map<NameUpdatedEvent, UpsertUserRequest>(context.Message);
            return sender.Send(request,context.CancellationToken);
        }
    }
}

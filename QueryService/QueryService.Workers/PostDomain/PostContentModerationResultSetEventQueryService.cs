using AutoMapper;
using MassTransit;
using MassTransit.Mediator;
using QueryService.Application.UseCases.PostUseCases.UpdatePost;

namespace QueryService.Workers.PostDomain
{
    internal class PostContentModerationResultSetEventQueryService(IMediator mediator, IMapper mapper) : IConsumer<PostContentModerationResultSetEventQueryService>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        public Task Consume(ConsumeContext<PostContentModerationResultSetEventQueryService> context) =>
            _mediator
                .Send(
                    _mapper.Map<PostContentModerationResultSetEventQueryService, UpdatePostRequest>(context.Message),
                    context.CancellationToken
                );
    }
}

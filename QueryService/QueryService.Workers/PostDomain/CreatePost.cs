using AutoMapper;
using MassTransit;
using MassTransit.Mediator;
using QueryService.Application.UseCases.PostUseCases.CreatePost;
using Shared.Events.PostService;

namespace QueryService.Workers.PostDomain
{
    internal class CreatePost(IMediator mediator, IMapper mapper) : IConsumer<PostPreprocessingCompletedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        public Task Consume(ConsumeContext<PostPreprocessingCompletedEvent> context) =>
            _mediator
                .Send(
                    _mapper.Map<PostPreprocessingCompletedEvent,CreatePostRequest>(context.Message),
                    context.CancellationToken
                );
    }
}

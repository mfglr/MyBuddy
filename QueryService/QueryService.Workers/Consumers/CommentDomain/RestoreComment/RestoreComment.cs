using AutoMapper;
using MassTransit;
using MassTransit.Mediator;
using QueryService.Application.UseCases.CommentUseCases.UpdateComent;
using Shared.Events.Comment;

namespace QueryService.Workers.Consumers.CommentDomain.RestoreComment
{
    internal class RestoreComment(IMediator mediator, IMapper mapper) : IConsumer<CommentRestoredEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        public Task Consume(ConsumeContext<CommentRestoredEvent> context) =>
            _mediator.Send(
                _mapper.Map<CommentRestoredEvent, UpdateCommentRequest>(context.Message),
                context.CancellationToken
            );
    }
}

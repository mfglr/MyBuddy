using AutoMapper;
using MassTransit;
using MassTransit.Mediator;
using QueryService.Application.UseCases.CommentUseCases.UpdateComent;
using Shared.Events.Comment;

namespace QueryService.Workers.Consumers.CommentDomain.DeleteComment
{
    internal class DeleteComment(IMediator mediator, IMapper mapper) : IConsumer<CommentDeletedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        public Task Consume(ConsumeContext<CommentDeletedEvent> context) =>
            _mediator.Send(
                _mapper.Map<CommentDeletedEvent, UpdateCommentRequest>(context.Message),
                context.CancellationToken
            );
    }
}

using AutoMapper;
using CommentService.Application.UseCases.RestoreCommentReplies;
using MassTransit;
using MassTransit.Mediator;
using Shared.Events.Comment;

namespace CommetService.Workers.Consumers.RestoreRepliesOnCommentRestored
{
    internal class RestoreRepliesOnCommentRestored(IMediator mediator, IMapper mapper, IPublishEndpoint publisheEndpoint) : IConsumer<CommentRestoredEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publisheEndpoint = publisheEndpoint;

        public async Task Consume(ConsumeContext<CommentRestoredEvent> context)
        {
            var client = _mediator.CreateRequestClient<RestoreCommentRepliesRequest>();
            var response = await client.GetResponse<RestoreCommentRepliesResponse>(new(context.Message.Id), context.CancellationToken);
            var @events = _mapper.Map<IEnumerable<RestoreCommentRepliesResponse_Comment>, IEnumerable<CommentRestoredEvent>>(response.Message.Comments);
            await _publisheEndpoint.PublishBatch(@events,context.CancellationToken);
        }
    }
}

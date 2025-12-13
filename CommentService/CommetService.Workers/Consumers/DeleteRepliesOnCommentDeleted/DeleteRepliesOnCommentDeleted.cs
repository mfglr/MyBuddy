using AutoMapper;
using CommentService.Application.UseCases.DeleteComentReplies;
using MassTransit;
using MassTransit.Mediator;
using Shared.Events.Comment;

namespace CommetService.Workers.Consumers.DeleteRepliesOnCommentDeleted
{
    internal class DeleteRepliesOnCommentDeleted(IMediator mediator, IMapper mapper, IPublishEndpoint publishEndpoint) : IConsumer<CommentDeletedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Consume(ConsumeContext<CommentDeletedEvent> context)
        {
            var client = _mediator.CreateRequestClient<DeleteCommentRepliesRequest>();
            var request = new DeleteCommentRepliesRequest(context.Message.Id);
            var response = await client.GetResponse<DeleteCommentRepliesResponse>(request, context.CancellationToken);

            var @events = _mapper.Map<IEnumerable<DeleteCommentRepliesResponse_Comment>, IEnumerable<CommentDeletedEvent>>(response.Message.Comments);
            await _publishEndpoint.PublishBatch(@events, context.CancellationToken);

        }
    }
}

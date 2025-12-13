using AutoMapper;
using CommentService.Application.UseCases.DeletePostComments;
using MassTransit;
using MassTransit.Mediator;
using Shared.Events.Comment;
using Shared.Events.PostService;

namespace CommetService.Workers.Consumers.DeletePostCommentsOnPostDeleted
{
    internal class DeletePostCommentsOnPostDeleted(IMediator mediator, IMapper mapper, IPublishEndpoint publishEndpoint) : IConsumer<PostDeletedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Consume(ConsumeContext<PostDeletedEvent> context)
        {
            var client = _mediator.CreateRequestClient<DeletePostCommentsRequest>();
            var response = await client.GetResponse<DeletePostCommentsResponse>(new(context.Message.Id), context.CancellationToken);
            var events = _mapper.Map<IEnumerable<DeletePostCommentsResponse_Comment>, IEnumerable<CommentDeletedEvent>>(response.Message.Comments);
            await _publishEndpoint.PublishBatch(events, context.CancellationToken);
        }
    }
}

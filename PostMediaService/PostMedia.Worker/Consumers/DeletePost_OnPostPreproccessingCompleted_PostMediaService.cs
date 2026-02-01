using MassTransit;
using MediatR;
using PostMedia.Application.UseCases.DeletePost;
using Shared.Events.PostMediaService;

namespace PostMedia.Worker.Consumers
{
    internal class DeletePost_OnPostPreproccessingCompleted_PostMediaService(ISender sender) : IConsumer<PostMediaPreprocessingCompletedEvent>
    {
        public Task Consume(ConsumeContext<PostMediaPreprocessingCompletedEvent> context) =>
            sender
                .Send(
                    new DeletePostRequest(context.Message.Id),
                    context.CancellationToken
                );
    }
}

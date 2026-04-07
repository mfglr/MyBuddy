using AuthServer.Application.UseCases.SetMedia;
using Shared.Events.MediaService;

namespace AuthServer.Worker.MassTransit.Consumers
{
    internal class SetMedia_OnMediaPreprocessingCompleted_Mapper
    {
        public SetMediaRequest Map(MediaPreprocessingCompletedEvent @event) =>
            new(
                @event.Id,
                @event.BlobName,
                @event.Context
            );
    }
}

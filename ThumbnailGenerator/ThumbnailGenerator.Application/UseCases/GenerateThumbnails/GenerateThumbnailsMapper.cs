using Shared.Events.MediaService;
using Shared.Events.SharedObjects;

namespace ThumbnailGenerator.Application.UseCases.GenerateThumbnails
{
    internal class GenerateThumbnailsMapper
    {
        public ThumbnailsGeneratedEvent Map(GenerateThumbnailsRequest request, IEnumerable<string> blobNames)
        {
            var thumbnails = new List<Thumbnail>();
            for (int i = 0; i < blobNames.Count(); i++)
            {
                var blobName = blobNames.ElementAt(i);
                var instruction = request.Instructions.ElementAt(i);
                thumbnails.Add(new(blobName, instruction.Resolution, instruction.IsSquare));
            }
            return new (request.Id, request.ContainerName, request.BlobName, thumbnails);
        }
    }
}

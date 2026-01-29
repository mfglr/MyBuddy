using Newtonsoft.Json;
using Orleans;

namespace PostService.Domain
{
    [GenerateSerializer]
    [Alias("PostService.Domain.Thumbnail")]
    [method: JsonConstructor]
    public class Thumbnail(string blobName, double resolution, bool isSquare)
    {
        [Id(0)]
        public string BlobName { get; private set; } = blobName;
        [Id(1)]
        public double Resolution { get; private set; } = resolution;
        [Id(2)]
        public bool IsSquare { get; private set; } = isSquare;
    }
}

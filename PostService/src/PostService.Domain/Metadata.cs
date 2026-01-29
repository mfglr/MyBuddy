using Newtonsoft.Json;
using Orleans;

namespace PostService.Domain
{
    [GenerateSerializer]
    [Alias("PostService.Domain.Metadata")]
    [method: JsonConstructor]
    public class Metadata(double width, double height, double duration)
    {
        public static readonly int MaxDurationInSeconds = 300;

        [Id(0)]
        public double Width { get; private set; } = width;
        [Id(1)]
        public double Height { get; private set; } = height;
        [Id(2)]
        public double Duration { get; private set; } = duration;

        public bool IsValid() => Duration > MaxDurationInSeconds;
    }
}

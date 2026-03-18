using System.Text.Json.Serialization;

namespace Media.Models
{
    [method:JsonConstructor]
    public record Metadata(double Width, double Height, double Duration)
    {
        [JsonIgnore]
        public double AspectRatio => Width / Height;
    }
}

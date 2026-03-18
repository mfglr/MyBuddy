using System.Text.Json.Serialization;

namespace Media.Models
{
    [method: JsonConstructor]
    public record Thumbnail(string BlobName, double Resolution, bool IsSquare);
}

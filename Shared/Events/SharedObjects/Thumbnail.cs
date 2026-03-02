using System.Text.Json.Serialization;

namespace Shared.Events.SharedObjects
{
    [method: JsonConstructor]
    public record Thumbnail(string BlobName, double Resolution, bool IsSquare);
}

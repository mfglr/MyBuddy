using System.Text.Json.Serialization;

namespace Media.Models
{
    [method: JsonConstructor]
    public record ThumbnailInstruction(
        double Resolution,
        bool IsSquare
    );
}

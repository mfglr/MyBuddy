using System.Text.Json.Serialization;

namespace Media.Models
{
    [method: JsonConstructor]
    public record TranscodingInstruction(double Resolution);
}

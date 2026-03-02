using System.Text.Json.Serialization;

namespace Shared.Events.SharedObjects
{
    [method: JsonConstructor]
    public record TranscodingInstruction(double Resolution);
}

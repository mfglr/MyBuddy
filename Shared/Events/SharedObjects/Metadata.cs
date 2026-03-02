using System.Text.Json.Serialization;

namespace Shared.Events.SharedObjects
{
    [method:JsonConstructor]
    public record Metadata(double Width, double Height, double Duration);
}

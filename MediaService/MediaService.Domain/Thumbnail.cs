using System.Text.Json.Serialization;

namespace MediaService.Domain
{
    [method: JsonConstructor]
    public class Thumbnail(string blobName, double resulation, bool isSquare)
    {
        public string BlobName { get; private set; } = blobName;
        public double Resulation { get; private set; } = resulation;
        public bool IsSquare { get; private set; } = isSquare;
    }
}

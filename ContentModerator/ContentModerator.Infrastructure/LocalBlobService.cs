using Microsoft.Extensions.Configuration;
using ContentModerator.Application;

namespace ContentModerator.Infrastructure
{
    internal class LocalBlobService(IConfiguration configuration) : IBlobService
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<Stream> ReadAsync(string containerName, string blobName, CancellationToken cancellationToken)
        {
            var baseAddress = new Uri(_configuration["BlobService:ConnectionString"]!);
            var address = $"{baseAddress}/get/{containerName}/{blobName}";
            var client = new HttpClient();
            var stream = await client.GetStreamAsync(address, cancellationToken);

            return stream;
        }
    }
}

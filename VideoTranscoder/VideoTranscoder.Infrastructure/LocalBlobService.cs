using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using VideoTranscoder.Application;

namespace VideoTranscoder.Infrastructure
{
    internal class LocalBlobService(IConfiguration configuration) : IBlobService
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<string> UploadAsync(Stream stream, string containerName, CancellationToken cancellationToken)
        {
            var baseAddress = new Uri(_configuration["BlobService:ConnectionString"]!);
            var address = $"{baseAddress}/Upload";
            var client = new HttpClient();
            
            var form = new MultipartFormDataContent
            {
                { new StringContent(containerName), "containerName" },
                { new StreamContent(stream), "media", "media" }
            };

            var response = await client.PostAsync(address, form, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<List<string>>(content)!.First();
        }
        public async Task DeleteAsync(string containerName, string blobName, CancellationToken cancellationToken)
        {
            var baseAddress = new Uri(_configuration["BlobService:ConnectionString"]!);
            var address = $"{baseAddress}/delete";
            var client = new HttpClient();
            var json = JsonSerializer.Serialize( new { containerName, blobNames = new[] { blobName } } );
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = await client.PostAsync(address, content, cancellationToken);
            await message.Content.ReadAsStringAsync(cancellationToken);
        }
        public async Task<Stream> GetAsync(string containerName, string blobName, CancellationToken cancellationToken)
        {
            var baseAddress = new Uri(_configuration["BlobService:ConnectionString"]!);
            var address = $"{baseAddress}/get/{containerName}/{blobName}";
            var client = new HttpClient();
            return await client.GetStreamAsync(address, cancellationToken);
        }
    }
}

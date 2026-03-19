using AuthServer.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace AuthServer.Infrastructure.BlobService
{
    internal class LocalBlobService(IConfiguration configuration, RedisAccessTokenProvider accessTokenProvider) : IBlobService
    {
        public async Task DeleteAsync(string containerName, string blobName, CancellationToken cancellationToken)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(configuration["BlobService:Host"]!),
            };
            var accessToken = accessTokenProvider.Get();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            List<string> blobNames = [blobName];
            var content = JsonContent.Create(new { containerName, blobNames });
            await client.PostAsync("api/v1/blobs/delete", content, cancellationToken);
        }

        public async Task<string> UploadAsync(string containerName, IFormFile file, CancellationToken cancellationToken)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(configuration["BlobService:Host"]!),
            };
            var accessToken = accessTokenProvider.Get();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            using var stream = file.OpenReadStream();
            var streamContent = new StreamContent(stream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            var form = new MultipartFormDataContent
            {
                { new StringContent(containerName), "containerName" },
                { streamContent, "media", "media" }
            };
            var message = await client.PostAsync("api/v1/blobs/upload", form, cancellationToken);

            var content = await message.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<List<string>>(content)!.First();
        }
    }
}

namespace BlobService.Api.Auth
{
    internal class AuthOptions
    {
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
    }
}

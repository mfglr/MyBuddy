namespace UserService.Api.Identity
{
    internal class IdentityOptions
    {
        public required string Issuer { get; set; }
        public required string BaseUrl { get; set; }
        public required string Audience { get; set; }
    }
}

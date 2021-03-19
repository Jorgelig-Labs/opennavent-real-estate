namespace Jorgelig.Navent.HttpClients.Application
{
    public class ApplicationLoginResponse
    {
        public int? ExpiresIn { get; set; }
        public ApplicationRefreshTokenResponse RefreshToken { get; set; }
        public string? TokenType { get; set; }
        public object? AdditionalInformation { get; set; }
        public string? Value { get; set; }
        public string? Expiration { get; set; }
        public string?[]? Scope { get; set; }
        public bool? Expired { get; set; }
    }

    public class ApplicationRefreshTokenResponse
    {
        public string? Value { get; set; }
    }
}

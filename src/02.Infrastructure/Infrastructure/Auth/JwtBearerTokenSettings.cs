namespace Infrastructure.Auth;

public class JwtBearerTokenSettings
{
    public string SecretKey { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public int ExpiryTimeInSeconds { get; set; }
}
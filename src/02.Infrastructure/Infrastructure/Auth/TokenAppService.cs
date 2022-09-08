using Autofac.Core;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Token;

public class TokenAppService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenAppService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string Create(
        ICollection<Claim> claims,
        ICollection<string> roles,
        string userId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenSection = _configuration.GetSection(nameof(TokenSettings));
        var tokenSettings = tokenSection.Get<TokenSettings>();
        var key = Encoding.ASCII.GetBytes(tokenSettings.SecretKey);
  

        var tokenClaims = new ClaimsIdentity();
        tokenClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId));
        
        GenerateUserRolesToTokenClaims(ref tokenClaims,roles);
        GenerateUserClaimsToTokenClaims(ref tokenClaims, claims);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = tokenClaims,

            Expires = DateTime.UtcNow.AddSeconds(tokenSettings.ExpiryTimeInSeconds),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            Audience = tokenSettings.Audience,
            Issuer = tokenSettings.Issuer
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    private void GenerateUserRolesToTokenClaims(
        ref ClaimsIdentity tokenClaims, 
        ICollection<string> userRoles)
    {
        foreach (var role in userRoles)
        {
            tokenClaims.AddClaim(new Claim(ClaimTypes.Role, role));
        }
    }
    
    private void GenerateUserClaimsToTokenClaims(
        ref ClaimsIdentity tokenClaims, 
        ICollection<Claim> userClaims)
    {
        foreach (var claim in userClaims)
        {
            tokenClaims.AddClaim(new Claim(claim.Type, claim.Value));
        }
    }
}
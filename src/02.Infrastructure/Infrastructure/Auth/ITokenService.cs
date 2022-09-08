namespace Infrastructure.Auth;

public interface ITokenService
{
    string Create(
        ICollection<Claim> claims,
        ICollection<string> roles,
        string userId);
}
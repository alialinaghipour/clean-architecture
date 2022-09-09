using System.Security.Claims;

namespace ApplicationContracts.Contracts;

public interface ITokenService : ISingleton
{
    string Create(
        ICollection<Claim> claims,
        ICollection<string> roles,
        string userId);
}
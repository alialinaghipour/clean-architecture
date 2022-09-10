using ApplicationContracts.Contracts;
using Microsoft.AspNetCore.Authentication;

namespace Identity;

public interface ISignInManagementService : IScoped
{
    Task SignOut();
    Task SignIn(User user);
    bool IsSignIn(ClaimsPrincipal user);
    Task PasswordSignIn(PasswordSignInDto dto);
    Task<IEnumerable<AuthenticationScheme>> GetExternalAuthentication();
}
using Microsoft.AspNetCore.Authentication;

namespace Identity;

public class SignInManagementAppService : ISignInManagementService
{
    private readonly SignInManager<User> _signInManager;

    public SignInManagementAppService(
        SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task SignOut()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task SignIn(User user)
    {
        await _signInManager.SignInAsync(user, true);
    }

    public bool IsSignIn(ClaimsPrincipal user)
    {
        return _signInManager.IsSignedIn(user);
    }

    public async Task PasswordSignIn(PasswordSignInDto dto)
    {
        var result = await _signInManager.PasswordSignInAsync(
            dto.UserName,
            dto.Password,
            dto.RememberMe,
            dto.LockoutOnFailure);

        if (result.IsLockedOut)
            throw new YourAccountIsLockedException();
        if (!result.Succeeded)
            throw new SignInFailedException();
    }

    public async Task<IEnumerable<AuthenticationScheme>> GetExternalAuthentication()
    {
        return await _signInManager.GetExternalAuthenticationSchemesAsync();
    }
}
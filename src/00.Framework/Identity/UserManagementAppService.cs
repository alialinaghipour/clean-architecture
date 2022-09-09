using Microsoft.EntityFrameworkCore;

namespace Identity;

public class UserManagementAppService : IUserManagementService
{
    private readonly UserManager<User> _userManager;

    public UserManagementAppService(
        UserManager<User> userManager)

    {
        _userManager = userManager;
    }

    public async Task<string?> GetUserIdById(string id)
    {
        return await _userManager.Users
            .Select(_ => _.Id)
            .SingleOrDefaultAsync();
    }

    public async Task<User> FindByEmail(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task AddToRole(User user, string role)
    {
        await _userManager.AddToRoleAsync(user, role);
    }

    public async Task ChangePassword(
        User user,
        string oldPassword,
        string newPassword)
    {
        var checkPassword = await CheckPassword(user, oldPassword);

        if (checkPassword == false)
            throw new CurrentPasswordIsNotCorrectException();

        var changePassword = await _userManager.ChangePasswordAsync(
            user,
            oldPassword,
            newPassword);

        if (!changePassword.Succeeded)
            throw new ChangePasswordFailedException();
    }

    public async Task<User> ConfirmLogin(string userName,
        string password)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            throw new WrongUsernameOrPasswordException();

        if (!user.EmailConfirmed)
            throw new YourAccountHasNotBeenActivatedException();

        var verifyPassword = VerifyHashedPassword(user, password);
        if (!verifyPassword)
            throw new WrongUsernameOrPasswordException();

        return user;
    }

    public async Task<string> GetSecurityStamp(User user)
    {
        return await _userManager.GetSecurityStampAsync(user);
    }

    public async Task UpdateSecurityStamp(User user)
    {
        var result = await _userManager.UpdateSecurityStampAsync(user);

        if (!result.Succeeded)
            throw new UpdateSecurityStampFailedException();
    }

    public async Task ResetPassword(
        User user,
        string password)
    {
        var token = await _userManager
            .GeneratePasswordResetTokenAsync(user);
        var result = await _userManager
            .ResetPasswordAsync(user, token, password);

        if (!result.Succeeded)
            throw new ResetPasswordFailedException();
    }

    public async Task<User> Create(User user, string password)
    {
        var result =
            await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            throw new CreateUserFailedException();

        return user;
    }

    public async Task<User> FindById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        CheckUserExists(user);
        return user;
    }

    public async Task<User?> FindByUsername(string username)
    {
        return await _userManager.FindByNameAsync(username);
    }

    public async Task<IList<Claim>> GetClaims(User user)
    {
        return await _userManager.GetClaimsAsync(user);
    }

    public async Task<IList<string>> GetRoles(User user)
    {
        return await _userManager.GetRolesAsync(user);
    }

    public async Task<bool> CheckPassword(User user,
        string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task RemoveFromRole(User user, string role)
    {
        await _userManager.RemoveFromRoleAsync(user, role);
    }

    public async Task SetLockoutEnable(User user, bool lockout)
    {
        var result = await _userManager.SetLockoutEnabledAsync(user, lockout);

        if (result != IdentityResult.Success)
            throw new SetLockoutEnableFailedException();
    }

    public async Task<string> GeneratePasswordResetToken(User user)
    {
        return await _userManager.GeneratePasswordResetTokenAsync(user);
    }

    public bool VerifyHashedPassword(User user, string password)
    {
        var passwordVerifiedResult =
            _userManager.PasswordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                password);

        if (passwordVerifiedResult == PasswordVerificationResult.Success)
            return true;

        return false;
    }

    public async Task<bool> IsInRole(User user, string role)
    {
        return await _userManager.IsInRoleAsync(user, role);
    }

    public async Task ChangePassword(string id, UserChangePasswordDto dto)
    {
        var user = await FindById(id);

        var changePassword =
            await _userManager.ChangePasswordAsync(
                user,
                dto.CurrentPassword,
                dto.NewPassword);

        if (!changePassword.Succeeded)
            throw new CurrentPasswordIsNotCorrectException();
    }

    public async Task Delete(User user)
    {
        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
            throw new DeleteUserFailedException();
    }

    public async Task<string> GenerateEmailConfirmationToken(
        User user)
    {
        return await _userManager.GenerateEmailConfirmationTokenAsync(user);
    }

    public async Task ConfirmEmail(User user, string token)
    {
        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (!result.Succeeded)
            throw new ConfrimEmailFailedException();
    }

    private static void CheckUserExists(User? user)
    {
        if (user == null)
            throw new UserNotFoundException();
    }
}
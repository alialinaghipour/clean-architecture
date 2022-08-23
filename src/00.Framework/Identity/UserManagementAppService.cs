namespace Identity;

public class UserManagementAppService : IUserManagementService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserManagementAppService(
        UserManager<ApplicationUser> userManager)

    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser> FindByEmail(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task AddToRole(ApplicationUser user, string role)
    {
        await _userManager.AddToRoleAsync(user, role);
    }

    public async Task ChangePassword(
        ApplicationUser user,
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

    public async Task<ApplicationUser> ConfirmLogin(string userName,
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

    public async Task<string> GetSecurityStamp(ApplicationUser user)
    {
        return await _userManager.GetSecurityStampAsync(user);
    }

    public async Task UpdateSecurityStamp(ApplicationUser user)
    {
        var result = await _userManager.UpdateSecurityStampAsync(user);

        if (!result.Succeeded)
            throw new UpdateSecurityStampFailedException();
    }

    public async Task ResetPassword(
        ApplicationUser user,
        string password)
    {
        var token = await _userManager
            .GeneratePasswordResetTokenAsync(user);
        var result = await _userManager
            .ResetPasswordAsync(user, token, password);

        if (!result.Succeeded)
            throw new ResetPasswordFailedException();
    }

    public async Task<string> Create(ApplicationUser user, string password)
    {
        var result =
            await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            throw new CreateUserFailedException();

        return user.Id;
    }

    public async Task<ApplicationUser> FindById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        CheckUserExists(user);
        return user;
    }

    public async Task<ApplicationUser> FindByUsername(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        CheckUserExists(user);
        return user;
    }

    public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user)
    {
        return await _userManager.GetClaimsAsync(user);
    }

    public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
    {
        return await _userManager.GetRolesAsync(user);
    }

    public async Task<bool> CheckPassword(ApplicationUser user,
        string passoword)
    {
        return await _userManager.CheckPasswordAsync(user, passoword);
    }

    public async Task RemoveFromRole(ApplicationUser user, string role)
    {
        await _userManager.RemoveFromRoleAsync(user, role);
    }

    public async Task SetLockoutEnable(ApplicationUser user, bool lockout)
    {
        var result = await _userManager.SetLockoutEnabledAsync(user, lockout);

        if (result != IdentityResult.Success)
            throw new SetLockoutEnableFailedException();
    }

    public async Task<string> GeneratePasswordResetToken(ApplicationUser user)
    {
        return await _userManager.GeneratePasswordResetTokenAsync(user);
    }

    public bool VerifyHashedPassword(ApplicationUser user, string password)
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

    public async Task<bool> IsInRole(ApplicationUser user, string role)
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

    public async Task Delete(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
            throw new DeleteUserFailedException();
    }

    public async Task<string> GenerateEmailConfirmationToken(
        ApplicationUser user)
    {
        return await _userManager.GenerateEmailConfirmationTokenAsync(user);
    }

    public async Task ConfirmEmail(ApplicationUser user, string token)
    {
        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (!result.Succeeded)
            throw new ConfrimEmailFailedException();
    }

    private static void CheckUserExists(ApplicationUser? user)
    {
        if (user == null)
            throw new UserNotFoundException();
    }
}
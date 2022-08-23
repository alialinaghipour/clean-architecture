namespace Identity;

public interface IUserManagementService
{
    Task ConfirmEmail(ApplicationUser user, string token);
    Task<string> GenerateEmailConfirmationToken(ApplicationUser user);
    Task<string> GeneratePasswordResetToken(ApplicationUser user);
    bool VerifyHashedPassword(ApplicationUser user, string password);
    Task<bool> CheckPassword(ApplicationUser user, string password);
    Task<string> Create(ApplicationUser user, string password);
    Task SetLockoutEnable(ApplicationUser user, bool lockout);
    Task ChangePassword(string id, UserChangePasswordDto dto);
    Task<IList<Claim>> GetClaimsAsync(ApplicationUser user);
    Task<IList<string>> GetRolesAsync(ApplicationUser user);
    Task RemoveFromRole(ApplicationUser user, string role);
    Task<bool> IsInRole(ApplicationUser user, string role);
    Task<ApplicationUser> FindByUsername(string username);
    Task<ApplicationUser> FindByEmail(string email);
    Task AddToRole(ApplicationUser user, string role);
    Task<ApplicationUser> FindById(string id);
    Task Delete(ApplicationUser user);

    Task ChangePassword(
        ApplicationUser user,
        string oldPassword,
        string newPassword);

    Task<ApplicationUser> ConfirmLogin(string userName, string password);
    Task<string> GetSecurityStamp(ApplicationUser user);
    Task UpdateSecurityStamp(ApplicationUser user);
    Task ResetPassword(ApplicationUser user, string password);
}
using System.Security.Claims;
using ApplicationContracts.Contracts;
using Identity.Dto;

namespace Identity;

public interface IUserManagementService : IScoped
{
    Task ConfirmEmail(User user, string token);
    Task<string> GenerateEmailConfirmationToken(User user);
    Task<string> GeneratePasswordResetToken(User user);
    bool VerifyHashedPassword(User user, string password);
    Task<bool> CheckPassword(User user, string password);
    Task<User> Create(User user, string password);
    Task SetLockoutEnable(User user, bool lockout);
    Task ChangePassword(string id, UserChangePasswordDto dto);
    Task<IList<Claim>> GetClaims(User user);
    Task<IList<string>> GetRoles(User user);
    Task RemoveFromRole(User user, string role);
    Task<bool> IsInRole(User user, string role);
    Task<User?> FindByUsername(string username);
    Task<string?> GetUserIdById(string id);
    Task<User?> FindByEmail(string email);
    Task AddToRole(User user, string role);
    Task<User> FindById(string id);
    Task Delete(User user);

    Task ChangePassword(
        User user,
        string oldPassword,
        string newPassword);

    Task<User> ConfirmLogin(string userName, string password);
    Task<string> GetSecurityStamp(User user);
    Task UpdateSecurityStamp(User user);
    Task ResetPassword(User user, string password);
}
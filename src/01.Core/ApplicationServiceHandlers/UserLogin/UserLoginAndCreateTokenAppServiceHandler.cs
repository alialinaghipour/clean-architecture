using ApplicationContracts;
using ApplicationContracts.Contracts;
using ApplicationHandlerContracts.UserLogin;
using Identity;
using Identity.Exceptions;

namespace ApplicationServiceHandlers.UserLogin;

public class UserLoginAndCreateTokenAppServiceHandler 
    : IUserLoginAndCreateTokenServiceHandler
{
    private readonly IUserManagementService _userManagementService;
    private readonly ITokenService _tokenService;

    public UserLoginAndCreateTokenAppServiceHandler(
        IUserManagementService userManagementService,
        ITokenService tokenService)
    {
        _userManagementService = userManagementService;
        _tokenService = tokenService;
    }
    public async Task<string> Login(UserLoginDto dto)
    {
        var user = await _userManagementService.FindByUsername(dto.UserName);
        if (user.IsBlank())
            throw new WrongUsernameOrPasswordException();

        var checkedPassword = await _userManagementService
            .CheckPassword(user!, dto.Password);
        if (!checkedPassword)
            throw new WrongUsernameOrPasswordException();

        var claims = await _userManagementService.GetClaims(user!);
        var roles = await _userManagementService.GetRoles(user!);

        var token = _tokenService.Create(claims, roles, user!.Id);

        return token;
    }
}
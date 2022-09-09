using ApplicationContracts.Contracts;
using ApplicationHandlerContracts.UserLogin;
using ApplicationServiceHandlers.UserLogin;
using Identity;

namespace Test.Infrastructure.Factory.UserLogin;

public static class UserLoginServiceFactory
{
    public static IUserLoginAndCreateTokenServiceHandler Create(
        IUserManagementService userManagementService,
        ITokenService tokenService)
    {
        return new UserLoginAndCreateTokenAppServiceHandler(
            userManagementService,
            tokenService);
    }
}
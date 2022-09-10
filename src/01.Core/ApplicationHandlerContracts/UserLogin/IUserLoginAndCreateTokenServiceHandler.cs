using ApplicationContracts.Contracts;

namespace ApplicationHandlerContracts.UserLogin;

public interface IUserLoginAndCreateTokenServiceHandler : IScoped
{
    Task<string> LoginApi(UserLoginDto dto);
    Task LoginWeb(UserLoginDto dto);
}
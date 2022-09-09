using ApplicationContracts.Contracts;

namespace ApplicationHandlerContracts.UserLogin;

public interface IUserLoginAndCreateTokenServiceHandler : IScoped
{
    Task<string> Login(UserLoginDto dto);
}
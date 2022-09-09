using ApplicationHandlerContracts.UserLogin;

namespace Test.Infrastructure.Factory.UserLogin;

public static class UserLoginDtoFactory
{
    public static UserLoginDto Generate(
        string userName = "userName",
        string password = "password")
    {
        return new UserLoginDto
        {
            UserName = userName,
            Password = password,
            RepeatPassword = password
        };
    }
}
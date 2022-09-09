using Identity;
using Microsoft.AspNetCore.Identity;
using Persistence.Ef;

namespace Test.Infrastructure.Factory.Identity;

public static class UserManagementServiceFactory
{
    public static IUserManagementService Create(UserManager<User> manager)
    {
        return new UserManagementAppService(manager);
    }
}
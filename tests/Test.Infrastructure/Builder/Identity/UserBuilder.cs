using Identity;
using Test.Infrastructure.Factory.Dummies;

namespace Test.Infrastructure.Builder.Identity;

public class UserBuilder
{
    private readonly User _user;

    public UserBuilder()
    {
        var userName = DummyFactory.GenerateDummyString();
        var email = DummyFactory.GenerateDummyString()+"@gmail.com";
        _user = new User
        {
            Id = DummyFactory.GenerateDummyString(),
            Email = email,
            UserName = userName,
            NormalizedUserName =userName.ToUpper(),
            NormalizedEmail = email.ToUpper()
        };
    }

    public UserBuilder WithUserName(string userName)
    {
        _user.UserName = userName;
        _user.NormalizedUserName = userName.ToUpper();
        return this;
    }

    public User Build()
    {
        return _user;
    }
}
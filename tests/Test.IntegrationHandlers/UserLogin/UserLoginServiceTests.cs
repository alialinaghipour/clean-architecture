using System.Security.Claims;
using ApplicationHandlerContracts.UserLogin;
using ApplicationServiceHandlers.UserLogin;
using Identity.Exceptions;
using Moq;
using Test.Infrastructure.Builder.Identity;
using Test.Infrastructure.DatabaseConfig.Unit;
using Test.Infrastructure.Factory.Dummies;
using Test.Infrastructure.Factory.TokenService;
using Test.Infrastructure.Factory.UserLogin;

namespace Test.IntegrationHandlers.UserLogin;

[Collection(nameof(UserFixture))]
public class UserLoginServiceTests : UserFixture
{
    private readonly IUserManagementService _userManagementService;
    private readonly Mock<ITokenService> _tokenServiceMock;
    public UserLoginServiceTests(
        ApplicationDbContext context,
        IUserLoginAndCreateTokenServiceHandler loginAndCreateTokenServiceHandler,
        IUserManagementService userManagementService) 
        : base(
            context,
            loginAndCreateTokenServiceHandler)
    {
        _userManagementService = userManagementService;
        _tokenServiceMock = TokenServiceFactory.CreateServiceMock();
        LoginAndCreateTokenServiceHandler = UserLoginServiceFactory.Create(
            userManagementService, _tokenServiceMock.Object);
    }


    [Fact]
    public async Task UserLogin_user_login_properly()
    {
        var dto = UserLoginDtoFactory.Generate();
        var user = new UserBuilder()
            .WithUserName(dto.UserName)
            .Build();
       await _userManagementService.Create(user, dto.Password);
        var token = DummyFactory.GenerateDummyString();
        _tokenServiceMock.SetupCreateMethod(user.Id,token);
        
        var expected = await LoginAndCreateTokenServiceHandler.Login(dto);

        expected.Should().Be(token);
        _tokenServiceMock.VerifyCreateMethod(user.Id);
    }

    [Fact]
    public async Task UserLogin_throw_exception_user_not_found()
    {
        var dto = UserLoginDtoFactory.Generate();

        var expected = () => LoginAndCreateTokenServiceHandler.Login(dto);

        await expected.Should()
            .ThrowExactlyAsync<WrongUsernameOrPasswordException>();
    }
    
    [Fact]
    public async Task UserLogin_throw_exception_when_password_not_verify()
    {
        var dto = UserLoginDtoFactory.Generate();
        var user = new UserBuilder()
            .WithUserName(dto.UserName)
            .Build();
        Context.Save(user);

        var expected = () => LoginAndCreateTokenServiceHandler.Login(dto);

        await expected.Should()
            .ThrowExactlyAsync<WrongUsernameOrPasswordException>();
    }
}


namespace RestApi.Controllers;

[ApiController]
[Route("api/accounts")]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly ICreateMemberAndUserHandler _createMemberAndUserHandler;
    private readonly IUserLoginAndCreateTokenServiceHandler _loginAndCreateTokenServiceHandler;
    
    public AccountController(
        ICreateMemberAndUserHandler createMemberAndUserHandler,
        IUserLoginAndCreateTokenServiceHandler loginAndCreateTokenServiceHandler)
    {
        _createMemberAndUserHandler = createMemberAndUserHandler;
        _loginAndCreateTokenServiceHandler = loginAndCreateTokenServiceHandler;
    }
    
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task Register(CreateMemberAndUserDto dto)
    {
        await _createMemberAndUserHandler.Create(dto);
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<string> Login(UserLoginDto dto)
    {
        return await _loginAndCreateTokenServiceHandler.LoginApi(dto);
    }
    
}